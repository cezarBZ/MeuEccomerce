using MediatR;
using MeuEccomerce.API.Application.Commands.Category;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;

namespace MeuEccomerce.API.Application.CommandHandlers.Categories
{
    public class EnableCategoryCommandHandler : IRequestHandler<EnableCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public EnableCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(EnableCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            Category category = await _categoryRepository.GetByIdAsync(request.CategoryId) ?? throw new ArgumentNullException("Category not found"); 

            category.Enable();

            _categoryRepository.Update(category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
