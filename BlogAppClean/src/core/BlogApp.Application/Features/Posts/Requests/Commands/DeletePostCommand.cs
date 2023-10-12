using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLOGAPP.Application.Features.Posts.Requests.Commands;

public class DeletePostCommand : IRequest<Unit>
{
    public int Id { get; set; }
}