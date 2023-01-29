using MediatR;
using MeuEccomerce.API.Application.Commands.Product;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.API.Application.CommandHandlers.Products;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
{        
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public AddProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request)); 

        var categoryName = _categoryRepository.GetById(request.CategoryId).Name ?? throw new ArgumentException("Categoria não encontrada");
        
        Product product = new(
            request.Name,
            request.Description,
            request.Price,
            request.ImageUrl,
            request.Inventory,
            DateTime.Now,
            request.CategoryId,
            categoryName
            );
        _productRepository.Add(product);
        await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return true;
    }
}
