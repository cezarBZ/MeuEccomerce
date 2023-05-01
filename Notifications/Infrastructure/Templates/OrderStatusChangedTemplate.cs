using System.Globalization;

namespace Notifications.Infrastructure.Templates
{
    public class OrderStatusChangedTemplate : IEmailTemplate
    {
        public OrderStatusChangedTemplate(int orderNumber, string to, string status)
        {
            Subject = $"Your Order #{orderNumber} was updated";
            Content = $"Hi, how are you? This is a notification about your shipping order with code {orderNumber}. Update: {status}";
            To = to ;
        }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string To { get; set; }
    }
}
