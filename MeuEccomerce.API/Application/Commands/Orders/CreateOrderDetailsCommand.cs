using MediatR;

namespace MeuEccomerce.API.Application.Commands.Orders
{
    public class CreateOrderDetailsCommand : IRequest<bool>
    {
        public CreateOrderDetailsCommand(int orderId, Guid productId, int quantity, decimal price)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public int OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
