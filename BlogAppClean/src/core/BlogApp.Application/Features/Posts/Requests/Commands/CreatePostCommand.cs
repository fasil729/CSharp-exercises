using BLOGAPP.Application.DTOs.Post;
using BLOGAPP.Application.DTOs.Comment;
using BLOGAPP.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLOGAPP.Application.Features.Posts.Requests.Commands;

public class CreatePostCommand : IRequest<BaseCommandResponse>
{
    public PostCreateDTO PostDto { get; set; }
}