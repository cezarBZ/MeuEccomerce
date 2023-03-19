using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;
using MeuEccomerce.Infrastructure.Data;


namespace MeuEccomerce.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(ApplicationDataContext context) : base(context)
        {
        }
        public virtual void AddOrderDetails(OrderDetails orderDetails)
        {
            _context.Set<OrderDetails>().Add(orderDetails);
            _context.SaveChanges();
        }
    }
}
