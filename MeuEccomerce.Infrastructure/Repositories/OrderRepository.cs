using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;
using MeuEccomerce.Infrastructure.Data;


namespace MeuEccomerce.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(ApplicationDataContext context) : base(context)
        {
        }
    }
}
