using AutoMapper;
using BLOGAPP.Application.Exceptions;
using BLOGAPP.Application.Features.Posts.Requests.Commands;
using BLOGAPP.Application.Contracts.Persistence;
using BLOGAPP.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BLOGAPP.Application.Features.Posts.Handlers.Commands;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand,Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeletePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.PostRepository.Get(request.Id);

        if (post == null)
            throw new NotFoundException(nameof(Post), request.Id);

        await _unitOfWork.PostRepository.Delete(post);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}