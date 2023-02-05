using MediatR;
using MeuEccomerce.API.Application.Query.Categories;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;

namespace MeuEccomerce.API.Application.QueryHandler.Categories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories;
    }
}
