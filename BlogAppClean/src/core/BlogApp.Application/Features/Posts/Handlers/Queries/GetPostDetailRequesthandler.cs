using AutoMapper;
using BLOGAPP.Application.DTOs;
using BLOGAPP.Application.DTOs.Post;
using BLOGAPP.Application.Features.Posts.Requests.Queries;
using BLOGAPP.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BLOGAPP.Application.Features.Posts.Handlers.Queries;

public class GetPostDetailRequestHandler : IRequestHandler<GetPostDetailRequest, PostDTO>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostDetailRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    public async Task<PostDTO> Handle(GetPostDetailRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.Get(request.Id);
        return _mapper.Map<PostDTO>(post);
    }
}