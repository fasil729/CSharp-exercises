using AutoMapper;
using BLOGAPP.Application.DTOs;
using BLOGAPP.Application.DTOs.Comment;
using BLOGAPP.Application.Features.Comments.Requests.Queries;
using BLOGAPP.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BLOGAPP.Application.Features.Comments.Handlers.Queries;

public class GetCommentDetailRequestHandler : IRequestHandler<GetCommentDetailRequest, CommentDTO>
{
    private readonly ICommentRepository _commentRepository;

    private readonly IMapper _mapper;

    public GetCommentDetailRequestHandler(ICommentRepository postRepository, IMapper mapper)
    {
        _commentRepository = postRepository;
        _mapper = mapper;
    }
    public async Task<CommentDTO> Handle(GetCommentDetailRequest request, CancellationToken cancellationToken)
    {
        var post = await _commentRepository.Get(request.Id);
        return _mapper.Map<CommentDTO>(post);
    }
}