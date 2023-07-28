using APIIntro.Dtos.Categories;
using FluentValidation;

namespace APIIntro.Validations.Categories
{
    public class CategoryPostDtoValidation : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidation()
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
