using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuEccomerce.Domain.AggregatesModel.OrderAggregate
{
    public class OrderDetails
    {
        public OrderDetails(int orderId, Guid productId, int quantity, decimal price)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
