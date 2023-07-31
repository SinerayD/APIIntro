using APIIntro.Service.Dtos.Products;
using APIIntro.Service.Extensions;
using FluentValidation;


namespace APIIntro.Service.Validations.Products
{
    public class ProductPostDtoValidation : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.File.IsImage())
                {
                    context.AddFailure("File", "The file is not valid for image");
                }
                if (x.File.IsSizeOk(2))
                {
                    context.AddFailure("File", "The file max length should not exceed 2 MB");
                }
            });
        }
    }
}
.