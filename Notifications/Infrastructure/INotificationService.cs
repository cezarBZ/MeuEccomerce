namespace Notifications.Infrastructure
{
    public interface INotificationService
    {
        Task Send(IEmailTemplate template);
    }
}
