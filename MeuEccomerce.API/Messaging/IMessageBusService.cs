namespace MeuEccomerce.API.Messaging
{
    public interface IMessageBusService
    {
        void Publish(object data, string routingKey);
    }
}
