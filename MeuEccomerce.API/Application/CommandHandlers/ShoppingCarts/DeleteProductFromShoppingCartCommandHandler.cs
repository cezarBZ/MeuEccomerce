using MediatR;
using MeuEccomerce.API.Application.Commands.ShoppingCarts;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;

namespace MeuEccomerce.API.Application.CommandHandlers.ShoppingCarts
{
    public class DeleteProductFromShoppingCartCommandHandler : IRequestHandler<DeleteProductFromShoppingCartCommand, bool>
    {
        private readonly IShoppingCartItemRepository _repository;
        private readonly IProductRepository _productRepository;

        public DeleteProductFromShoppingCartCommandHandler(IShoppingCartItemRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductFromShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var shoppingCartItem = _repository.Get(x => x.ProductId == request.ProductId && x.ShoppingCartId == request.ShoppingCartId).FirstOrDefault();

            var product = await _productRepository.GetByIdAsync(request.ProductId);

            var localquantity = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localquantity = shoppingCartItem.Quantity;
                }
                else
                {
                    _repository.Delete(shoppingCartItem);
                }
            }
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
