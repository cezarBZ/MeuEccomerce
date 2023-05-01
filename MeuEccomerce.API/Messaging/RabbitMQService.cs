using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MeuEccomerce.API.Messaging
{
    public class RabbitMQService : IMessageBusService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string _exchange = "mye-service";
        public RabbitMQService()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = connectionFactory.CreateConnection("mye-service-publisher");

            _channel = _connection.CreateModel();
        }
        public void Publish(object data, string routingKey)
        {
            var type = data.GetType();

            var payload = JsonConvert.SerializeObject(data);
            var byteArray = Encoding.UTF8.GetBytes(payload);

            Console.WriteLine($"{type.Name} Published");

            _channel.BasicPublish(_exchange, routingKey, null, byteArray);
        }
    }
}
