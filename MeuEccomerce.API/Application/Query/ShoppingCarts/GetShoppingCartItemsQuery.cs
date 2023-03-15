using MediatR;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;

namespace MeuEccomerce.API.Application.Query.ShoppingCarts
{
    public class GetShoppingCartItemsQuery : IRequest<IReadOnlyList<ShoppingCartItem>> 
    {
        public GetShoppingCartItemsQuery(Guid shoppingCartId)
        {
            ShoppingCartId = shoppingCartId;
        }
        public Guid ShoppingCartId { get; set; }

    }
}
