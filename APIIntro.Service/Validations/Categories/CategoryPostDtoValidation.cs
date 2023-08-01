using APIIntro.Service.Dtos.Categories;
using APIIntro.Service.Dtos.Products;
using FluentValidation;

namespace APIIntro.Service.Validations.Categories
{
    public class CategoryPostDtoValidation : AbstractValidator<ProductPostDto>
    {
        public CategoryPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can not be empty")
                .NotNull().WithMessage("Name can not be null")
                .MinimumLength(3)
                .MaximumLength(30);

           
        }
    }
}
