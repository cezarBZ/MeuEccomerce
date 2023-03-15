using MediatR;
using MeuEccomerce.API.Application.Commands.Category;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;

namespace MeuEccomerce.API.Application.CommandHandlers.Categories
{
    public class DisableCategoryCommandHandler : IRequestHandler<DisableCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DisableCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(DisableCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            Category category = await _categoryRepository.GetByIdAsync(request.CategoryId) ?? throw new ArgumentNullException("Category not found"); 

            category.Disable();

            _categoryRepository.Update(category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
