using MediatR;
using MeuEccomerce.Domain.Events;

namespace MeuEccomerce.API.Application.EventHandlers.OrderEvents
{
    public class OrderStatusChangedEventHandlers : INotificationHandler<OrderStatusChangedEvent>
    {
        public Task Handle(OrderStatusChangedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
