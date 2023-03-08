using MediatR;
using MeuEccomerce.API.Application.Commands.ShoppingCarts;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;

namespace MeuEccomerce.API.Application.CommandHandlers.ShoppingCarts;

public class AddItemToShoppingCartCommandHandler : IRequestHandler<AddItemToShoppingCartCommand, bool>
{
    private readonly IShoppingCartItemRepository _repository;
    private readonly IProductRepository _productRepository;

    public AddItemToShoppingCartCommandHandler(IShoppingCartItemRepository repository, IProductRepository productRepository)
    {
        _repository = repository;
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(AddItemToShoppingCartCommand request, CancellationToken cancellationToken)
    {
        var shoppingCartItem = _repository.Get(x => x.ProductId == request.ProductId && x.ShoppingCartId == request.ShoppingCartId).FirstOrDefault();

        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem(product.Id, 1, request.ShoppingCartId, product.Price);
            
             _repository.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Quantity ++;
            _repository.Update(shoppingCartItem);  
        }
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return true;
    }
}
