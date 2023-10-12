using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using  BLOGAPP.Application.DTOs.Comment;

namespace BLOGAPP.Application.DTOs.Comment.Validators;

public class CreateCommentDtoValidator : AbstractValidator<CommentCreateDTO>
{
    public CreateCommentDtoValidator()
    {
        Include(new ICommentDtoValidator());
        RuleFor(p => p.CreatedBy)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(20).WithMessage("{PropertyName} cannot exceed 100 characters.");
    }
}