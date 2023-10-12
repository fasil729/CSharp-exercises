using AutoMapper;
using BLOGAPP.Application.DTOs.Post.Validators;
using BLOGAPP.Application.Exceptions;
using BLOGAPP.Application.Features.Posts.Requests.Commands;
using BLOGAPP.Application.Contracts.Persistence;
using BLOGAPP.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLOGAPP.Application.Responses;
using System.Linq;

namespace BLOGAPP.Application.Features.Posts.Handlers.Commands;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePostCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreatePostDtoValidator();
        var validationResult = await validator.ValidateAsync(request.PostDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Post creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {

            var post = _mapper.Map<Post>(request.PostDto);

            post = await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.Save();
            
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = post.Id;
        }
        return response;
    }
}