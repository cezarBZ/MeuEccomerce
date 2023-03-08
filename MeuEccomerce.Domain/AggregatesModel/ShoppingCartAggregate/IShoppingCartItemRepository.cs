using MeuEccomerce.Domain.Core.Data;

namespace MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;

public interface IShoppingCartItemRepository : IRepository<ShoppingCartItem, int>
{
}
