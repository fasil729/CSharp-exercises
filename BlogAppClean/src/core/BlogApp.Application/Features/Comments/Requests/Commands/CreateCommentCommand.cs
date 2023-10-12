using BLOGAPP.Application.DTOs.Comment;
using BLOGAPP.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLOGAPP.Application.Features.Comments.Requests.Commands;

public class CreateCommentCommand : IRequest<BaseCommandResponse>
{
    public CommentCreateDTO CommentDto { get; set; }
}