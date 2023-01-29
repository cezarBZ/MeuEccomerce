using MediatR;
using MeuEccomerce.API.Application.Query.Products;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.API.Application.QueryHandler.Products;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IProductRepository categoryRepository)
    {
        _productRepository = categoryRepository;
    }


    public async Task<IReadOnlyList<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();
        return products;
    }
}


