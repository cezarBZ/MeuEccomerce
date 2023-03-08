using MediatR;

namespace MeuEccomerce.API.Application.Commands.ShoppingCarts
{
    public class DeleteProductFromShoppingCartCommand : IRequest<bool>
    {
        public DeleteProductFromShoppingCartCommand(Guid productId, Guid shoppingCartId)
        {
            ProductId = productId;
            ShoppingCartId = shoppingCartId;
        }
        public Guid ProductId { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}
