using BLOGAPP.Application.DTOs;
using BLOGAPP.Application.DTOs.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLOGAPP.Application.Features.Comments.Requests.Queries;

public class GetPostCommentListRequest : IRequest<List<CommentDTO>>
{
    public int PostId { get; set; }
}