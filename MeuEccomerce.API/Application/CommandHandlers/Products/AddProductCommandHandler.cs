using MediatR;
using MeuEccomerce.API.Application.Commands.Product;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.API.Application.CommandHandlers.Products;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
{        
    private readonly IProductRepository _productRepository;

    public AddProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request)); 

        Product product = new(
            request.Name,
            request.Description,
            request.Price,
            request.ImageUrl,
            request.Inventory,
            DateTime.Now,
            request.CategoryId
            );
        _productRepository.Add(product);
        await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return true;
    }
}
