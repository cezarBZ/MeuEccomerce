using MediatR;
using MeuEccomerce.API.Application.Models.ViewModels;
using MeuEccomerce.API.Application.Query.Products;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.API.Application.QueryHandler.Products;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<ProductViewModel>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public GetAllProductsQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;

    }

    public async Task<IReadOnlyList<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();
        var categories = await _categoryRepository.GetAllAsync();

        return products.Join(categories,
                p => p.CategoryId,
                c => c.Id,
                (p, c) => new ProductViewModel
                {
                    Name = p.Name,
                    CategoryName = c.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Inventory = p.Inventory,
                    CategoryId = p.CategoryId,
                }).ToList();
    }
}


