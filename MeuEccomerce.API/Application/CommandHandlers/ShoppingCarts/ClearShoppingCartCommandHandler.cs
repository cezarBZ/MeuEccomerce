using MediatR;
using MeuEccomerce.API.Application.Commands.ShoppingCarts;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;

namespace MeuEccomerce.API.Application.CommandHandlers.ShoppingCarts
{
    public class ClearShoppingCartCommandHandler : IRequestHandler<ClearShoppingCartCommand, bool>
    {
    private readonly IShoppingCartItemRepository _repository;

        public ClearShoppingCartCommandHandler(IShoppingCartItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ClearShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var shoppingCartItems = _repository.Get(carrinho => carrinho.ShoppingCartId == request.ShoppingCartId);
            foreach (var item in shoppingCartItems)
            {
                _repository.Delete(item);
            }

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
