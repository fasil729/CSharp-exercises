using BLOGAPP.Application.DTOs;
using BLOGAPP.Application.DTOs.Post;
using BLOGAPP.Application.DTOs.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLOGAPP.Application.Features.Posts.Requests.Queries;

public class GetPostListRequest : IRequest<List<PostDTO>>
{
}