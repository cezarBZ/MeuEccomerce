using MeuEccomerce.Domain.Core.Data;

namespace MeuEccomerce.Domain.AggregatesModel.OrderAggregate;

public interface IOrderRepository : IRepository<Order, int> {}
