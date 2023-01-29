using FluentValidation;
using MeuEccomerce.API.Application.Commands.Category;


namespace MeuEccomerce.API.Validators
{
    public class CategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(c => c.Name).MaximumLength(100).WithMessage("Name must be less than 100 characters");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Describe this category");
            RuleFor(c => c.Description).MaximumLength(250).WithMessage("Description must be less than 100 characters");
            RuleFor(c => c.ImageUrl).MaximumLength(500).WithMessage("Image URL must be less than 500 characters");

        }
    }
}
