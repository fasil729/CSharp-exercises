using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using  BLOGAPP.Application.DTOs.Comment;

namespace BLOGAPP.Application.DTOs.Comment.Validators;

public class ICommentDtoValidator : AbstractValidator<ICommentDTO>
{
    public ICommentDtoValidator()
    {
        RuleFor(p => p.Text)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(p => p.Postid).NotNull().WithMessage("{PropertyName} must be present");
    }
}