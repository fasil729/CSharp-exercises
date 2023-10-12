using AutoMapper;
using BLOGAPP.Application.DTOs;
using BLOGAPP.Application.DTOs.Post;
using BLOGAPP.Application.Features.Posts.Requests.Queries;
using BLOGAPP.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BLOGAPP.Domain;

namespace BLOGAPP.Application.Features.Posts.Handlers.Queries;

public class GetPostListRequestHandler : IRequestHandler<GetPostListRequest, List<PostDTO>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostListRequestHandler(IPostRepository postRepository,
            IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostDTO>> Handle(GetPostListRequest request, CancellationToken cancellationToken)
    {
        var posts = new List<Post>();
        var postDTOs = new List<PostDTO>();

        posts = await _postRepository.GetPostsWithDetails();
        postDTOs = _mapper.Map<List<PostDTO>>(posts);
        return postDTOs;
    }
}