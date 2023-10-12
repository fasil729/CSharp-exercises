using BLOGAPP.Application.DTOs.Post;
using BLOGAPP.Application.DTOs.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLOGAPP.Application.Features.Comments.Requests.Commands;

public class UpdateCommentCommand : IRequest<Unit>
{
    public CommentUpdateDTO CommentDto { get; set; }
}