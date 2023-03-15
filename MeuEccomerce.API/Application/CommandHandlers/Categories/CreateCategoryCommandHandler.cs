using MediatR;
using MeuEccomerce.API.Application.Commands.Category;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;

namespace MeuEccomerce.API.Application.CommandHandlers.Categories;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var category = new Category(
            request.Name,
            request.Description,
            request.ImageUrl
            );
        _categoryRepository.Add(category);
        await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return true;
    }
}
