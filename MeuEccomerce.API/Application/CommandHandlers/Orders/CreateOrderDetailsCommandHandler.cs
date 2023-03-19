using MediatR;
using MeuEccomerce.API.Application.Commands.Orders;
using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;

namespace MeuEccomerce.API.Application.CommandHandlers.Orders
{
    public class CreateOrderDetailsCommandHandler : IRequestHandler<CreateOrderDetailsCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderDetailsCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<bool> Handle(CreateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var orderDetails = new OrderDetails(request.OrderId, request.ProductId, request.Quantity, request.Price);

            _orderRepository.AddOrderDetails(orderDetails);
            return Task.FromResult(true);
        }
    }
}
