using MediatR;

namespace MeuEccomerce.API.Application.Commands.ShoppingCarts
{
    public class AddItemToShoppingCartCommand : IRequest<bool>
    {
        public AddItemToShoppingCartCommand(Guid productId, Guid shoppingCartId)
        {
            ProductId = productId;
            ShoppingCartId = shoppingCartId;
        }
        public Guid ProductId { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}
