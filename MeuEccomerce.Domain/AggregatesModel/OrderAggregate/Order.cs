using MeuEccomerce.Domain.AggregatesModel.UserAggregate;
using MeuEccomerce.Domain.Core.Models;

namespace MeuEccomerce.Domain.AggregatesModel.OrderAggregate;

public class Order : Entity<int>, IAggregateRoot
{
    public Order(decimal totalOrderPrice, int totalOrderItems, string customerId)
    {

        TotalOrderPrice = totalOrderPrice;
        TotalOrderItems = totalOrderItems;
        OrderSent = null;
        OrderDelivered = null;
        CustomerId = customerId;
        Status = OrderStatus.Created;
    }


    public string CustomerId { get; set; }
    public OrderStatus Status { get; set; }
    private int _statusId;
    public decimal TotalOrderPrice { get; set; }
    public int TotalOrderItems { get; set; }
    public DateTime? OrderSent { get; set; }
    public DateTime? OrderDelivered { get; set; }
}
