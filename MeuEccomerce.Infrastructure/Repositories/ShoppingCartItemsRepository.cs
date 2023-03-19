using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;
using MeuEccomerce.Infrastructure.Data;

namespace MeuEccomerce.Infrastructure.Repositories
{
    public class ShoppingCartItemsRepository : Repository<ShoppingCartItem, int>, IShoppingCartItemRepository
    {
        public ShoppingCartItemsRepository(ApplicationDataContext context) : base(context)
        {
        }
    }
}
