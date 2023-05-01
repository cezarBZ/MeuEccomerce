using MediatR;
using MeuEccomerce.API.Application.Commands.Orders;
using MeuEccomerce.API.Application.Query.ShoppingCarts;
using MeuEccomerce.API.Application.Services;
using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;

using System.Security.Claims;

namespace MeuEccomerce.API.Application.CommandHandlers.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly ShoppingCartService _shoppingCartService;
        private readonly IMediator _mediator;
        private readonly IOrderRepository  _orderRepository;
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateOrderCommandHandler(ShoppingCartService shoppingCartService, IMediator mediator, IOrderRepository orderRepository, IHttpContextAccessor httpContextAccessor)
        {
            _shoppingCartService = shoppingCartService;
            _mediator = mediator;
            _orderRepository = orderRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetShoppingCartItemsQuery(_shoppingCartService.Id));
            var quantidade = items.Sum(item => item.Quantity);
            if (items.Count == 0)
            {
                throw new Exception("Shopping cart empty");
            }
            var currentUser = _httpContextAccessor.HttpContext.User ;
            
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var totalPrice = await _mediator.Send(new GetShoppingCartTotalPriceQuery(_shoppingCartService.Id));

            var order = new Order(
                    totalPrice,
                    quantidade,
                    userId
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
