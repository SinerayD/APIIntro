﻿using APIIntro.Service.Dtos.Categories;
using FluentValidation;

namespace APIIntro.Service.Validations.Categories
{
    public class CategoryUpdateDtoValidation : AbstractValidator<ProductUpdateDto>
    {
        public CategoryUpdateDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name can not be null")
                .MinimumLength(3)
                .MaximumLength(30);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name can not be null")
                .MinimumLength(3)
                .MaximumLength(100);
        }
    }

}