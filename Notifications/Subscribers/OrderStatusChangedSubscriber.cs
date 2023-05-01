using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Notifications.Infrastructure;
using Notifications.Infrastructure.Templates;
using Notifications.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Globalization;
using System.Text;

namespace Notifications.Subscribers
{
    public class OrderStatusChangedSubscriber : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Queue = "notifications-service/order-status-changed";
        private const string RoutingKeySubscribe = "order-status-changed";
        private readonly IServiceProvider _serviceProvider;
        private const string MyeExchange = "mye-service";
        public OrderStatusChangedSubscriber(IServiceProvider serviceProvider)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = connectionFactory.CreateConnection("order-status-changed-consumer");

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(MyeExchange, "topic", true, false);

            _channel.QueueDeclare(
                queue: Queue,
                durable: true,
                exclusive: false,
                autoDelete: false);

            _channel.QueueBind(Queue, MyeExchange, RoutingKeySubscribe);

            _serviceProvider = serviceProvider;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var @event = JsonConvert.DeserializeObject<OrderStatusChangedEvent>(contentString);

                Console.WriteLine($"Message OrderStatusChangedEvent received with status {@event.OrderStatus}");

                Notify(@event).Wait();

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }

        public async Task Notify(OrderStatusChangedEvent @event)
        {
            using var scope = _serviceProvider.CreateScope();

            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

            var template = new OrderStatusChangedTemplate(@event.OrderNumber, @event.ContactEmail, @event.OrderStatus);

            await notificationService.Send(template);
        }
    }
}
