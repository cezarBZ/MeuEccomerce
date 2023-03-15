using FluentValidation;
using MeuEccomerce.API.Application.Commands.Product;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;

namespace MeuEccomerce.API.Validators
{
    public class ProductValidator : AbstractValidator<AddProductCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public ProductValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(c => c.Name).MaximumLength(100).WithMessage("Name must be less than 100 characters");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Describe this category");
            RuleFor(c => c.Description).MaximumLength(250).WithMessage("Description must be less than 100 characters");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Price must be declared");
            RuleFor(p => p.Inventory).NotEmpty().WithMessage("Inventory is required");
            RuleFor(x => x.CategoryId)
                .Custom((categoryId, context) =>
                {

                    var category = _categoryRepository.GetById(categoryId);
                    if (category == null)
                    {
                        context.AddFailure("The categoryId does not exist in the database.");
                    }
                });
            _categoryRepository = categoryRepository;
        }
    }
}
