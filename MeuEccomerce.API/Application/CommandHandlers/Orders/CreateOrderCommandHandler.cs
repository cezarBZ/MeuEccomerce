using MediatR;
using MeuEccomerce.API.Application.Commands.Orders;
using MeuEccomerce.API.Application.Query.ShoppingCarts;
using MeuEccomerce.API.Application.Services;
using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;

namespace MeuEccomerce.API.Application.CommandHandlers.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly ShoppingCartService _shoppingCartService;
        private readonly IMediator _mediator;
        private readonly IOrderRepository  _orderRepository;

        public CreateOrderCommandHandler(ShoppingCartService shoppingCartService, IMediator mediator, IOrderRepository orderRepository)
        {
            _shoppingCartService = shoppingCartService;
            _mediator = mediator;
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetShoppingCartItemsQuery(_shoppingCartService.Id));
            var quantidade = items.Sum(item => item.Quantity);
            

            var totalPrice = await _mediator.Send(new GetShoppingCartTotalPriceQuery(_shoppingCartService.Id));

            var order = new Order(
                    request.FirstName,
                    request.LastName,
                    request.Address1,
                    request.Address2,
                    request.ZipCode,
                    request.State,
                    request.City,
                    request.PhoneNumber,
                    request.Email,
                    totalPrice,
                    quantidade,
                    request.OrderSent,
                    request.OrderDelivered
            );
            _orderRepository.Add(order);
            foreach (var item in items)
            {
                await _mediator.Send(new CreateOrderDetailsCommand(order.Id, item.ProductId, item.Quantity, item.Price));
            }
            
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
