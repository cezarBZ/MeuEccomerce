namespace Notifications.Models
{
    public class OrderStatusChangedEvent
    {
        public int OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string ContactEmail { get; set; }
        public string Description { get; set; }
    }
}
