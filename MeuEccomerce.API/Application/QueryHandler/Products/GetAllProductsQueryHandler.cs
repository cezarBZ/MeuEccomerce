using MediatR;
using MeuEccomerce.API.Application.Models.DTO_s;
using MeuEccomerce.API.Application.Query.Products;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.API.Application.QueryHandler.Products;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<ProductDTO>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;

    }

    public async Task<IReadOnlyList<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();

        var productDTOs = from p in products
                          let category = _categoryRepository.GetByIdAsync(p.CategoryId)
                          select new ProductDTO
                          {
                              Id = p.Id,
                              Name = p.Name,
                              CategoryName = category.Result.Name,
                              Description = p.Description,
                              Price = p.Price,
                              ImageUrl = p.ImageUrl,
                              Inventory = p.Inventory,
                              CategoryId = p.CategoryId,
                          };

        return productDTOs.ToList();
    }
}


