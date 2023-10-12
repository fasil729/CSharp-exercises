using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLOGAPP.Application.Features.Comments.Requests.Commands;

public class DeleteCommentCommand : IRequest<Unit>
{
    public int Id { get; set; }
}