using AutoMapper;
using MediatR;
using MeuEccomerce.API.Application.Models.DTO_s;
using MeuEccomerce.API.Application.Models.ViewModels;
using MeuEccomerce.API.Application.Query.Categories;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;

namespace MeuEccomerce.API.Application.QueryHandler.Categories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IReadOnlyList<CategoryDTO>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }


    public async Task<IReadOnlyList<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(c => c.OrderBy(o => o.Name));

        var categoriesMap = _mapper.Map<IReadOnlyList<CategoryDTO>>(categories);

        return categoriesMap;
    }
}
