using AutoMapper;
using BLOGAPP.Application.Exceptions;
using BLOGAPP.Application.Features.Comments.Requests.Commands;
using BLOGAPP.Application.Contracts.Persistence;
using BLOGAPP.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BLOGAPP.Application.Features.Comments.Handlers.Commands;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand,Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _unitOfWork.CommentRepository.Get(request.Id);

        if (comment == null)
            throw new NotFoundException(nameof(Post), request.Id);

        await _unitOfWork.CommentRepository.Delete(comment);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}