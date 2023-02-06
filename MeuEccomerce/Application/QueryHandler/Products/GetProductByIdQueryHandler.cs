using AutoMapper;
using MediatR;
using MeuEccomerce.API.Application.Models.DTO_s;
using MeuEccomerce.API.Application.Query.Products;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.API.Application.QueryHandler.Products;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id) ?? throw new ArgumentNullException("Product not found");
        var mapped = _mapper.Map<ProductDTO>(product);
        return mapped;
    }

}