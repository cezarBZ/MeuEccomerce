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

            Category category = _categoryRepository.GetById(request.CategoryId);

            if (category == null) throw new ArgumentNullException(nameof(category));

            category.Enable();

            _categoryRepository.Update(category);
            await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
