using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;
using MeuEccomerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuEccomerce.Infrastructure.Repositories
{
    public class ShoppingCartItemsRepository : Repository<ShoppingCartItem, int>, IShoppingCartItemRepository
    {
        public ShoppingCartItemsRepository(ApplicationDataContext context) : base(context)
        {
        }
        
            
        
    }
}
