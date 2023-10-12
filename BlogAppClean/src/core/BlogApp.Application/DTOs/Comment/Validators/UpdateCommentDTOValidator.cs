using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using  BLOGAPP.Application.DTOs.Comment;

namespace BLOGAPP.Application.DTOs.Comment.Validators;

public class UpdateCommentDtoValidator : AbstractValidator<CommentUpdateDTO>
{
    public UpdateCommentDtoValidator()
    {
        Include(new ICommentDtoValidator());

        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        RuleFor(p => p.UpdatedBy)
                    .NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(p => p.UpdatedBy)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(20).WithMessage("{PropertyName} cannot exceed 100 characters.");    }
}