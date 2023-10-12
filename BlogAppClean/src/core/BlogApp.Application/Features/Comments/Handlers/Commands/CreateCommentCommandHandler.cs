using AutoMapper;
using BLOGAPP.Application.DTOs.Comment;
using BLOGAPP.Application.DTOs.Comment.Validators;
using BLOGAPP.Application.Exceptions;
using BLOGAPP.Application.Features.Comments.Requests.Commands;
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

namespace BLOGAPP.Application.Features.Comments.Handlers.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCommentCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateCommentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CommentDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Post creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        else
        {

            var comment = _mapper.Map<Comment>(request.CommentDto);

            comment = await _unitOfWork.CommentRepository.Add(comment);
            await _unitOfWork.Save();
            
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = comment.Id;
        }
        return response;
    }
}