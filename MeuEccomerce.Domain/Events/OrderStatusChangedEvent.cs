using MediatR;

namespace MeuEccomerce.Domain.Events
{
    public class OrderStatusChangedEvent : INotification
    {
        public OrderStatusChangedEvent(int orderNumber, string orderStatus, string contactEmail, string description)
        {
            OrderNumber = orderNumber;
            OrderStatus = orderStatus;
            ContactEmail = contactEmail;
            Description = description;
        }

        public int OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string ContactEmail { get; set; }
        public string Description { get; set; }
    }
}
