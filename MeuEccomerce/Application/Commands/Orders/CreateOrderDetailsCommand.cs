using MediatR;

namespace MeuEccomerce.API.Application.Commands.Orders
{
    public class CreateORderDetailsCommand : IRequest<bool>
    {
        public CreateORderDetailsCommand(int id, int orderId, Guid productId, int quantity, decimal price)
        {
            Id = id;
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
