using MediatR;

namespace MeuEccomerce.API.Application.Commands.ShoppingCarts
{
    public class ClearShoppingCartCommand : IRequest<bool>
    {
        public ClearShoppingCartCommand(Guid shoppingCartId)
        {
            ShoppingCartId = shoppingCartId;
        }
        public Guid ShoppingCartId { get; set; }
    }
}
