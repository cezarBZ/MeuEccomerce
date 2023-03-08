using MediatR;

namespace MeuEccomerce.API.Application.Query.ShoppingCarts
{
    public class GetShoppingCartTotalPriceQuery : IRequest<Decimal>
    {
        public GetShoppingCartTotalPriceQuery(Guid shoppingCartId)
        {
            ShoppingCartId = shoppingCartId;
        }
        public Guid ShoppingCartId { get; set; }
    }
}
