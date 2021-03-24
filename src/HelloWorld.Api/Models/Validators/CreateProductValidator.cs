using FluentValidation;

namespace HelloWorld.Api.Models.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithMessage("Invalid field length");

            RuleFor(p => p.Description)
                .MaximumLength(500)
                .WithMessage("Invalid field length");

            RuleFor(p => p.RetailPrice)
                .GreaterThan(0);
        }
    }
}
