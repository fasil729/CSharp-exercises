using AutoMapper;
using BLOGAPP.Application.DTOs;
using BLOGAPP.Application.DTOs.Comment;
using BLOGAPP.Application.Features.Comments.Requests.Queries;
using BLOGAPP.Application.Contracts.Persistence;
using BLOGAPP.Application.Exceptions;

using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BLOGAPP.Domain;

namespace BLOGAPP.Application.Features.Comments.Handlers.Queries;

public class GetPostCommentListRequestHandler : IRequestHandler<GetPostCommentListRequest, List<CommentDTO>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetPostCommentListRequestHandler(ICommentRepository commentRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
    {
        _commentRepository = commentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        this._httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<CommentDTO>> Handle(GetPostCommentListRequest request, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.PostRepository.Get(request.PostId);

        if (post == null)
            throw new NotFoundException(nameof(Post), request.PostId);

        var comments = new List<Comment>();
        var commentDTOs = new List<CommentDTO>();

        comments = await _commentRepository.GetPostComments(request.PostId);
        commentDTOs = _mapper.Map<List<CommentDTO>>(comments);
        return commentDTOs;
    }
}