using MediatR;

namespace MeuEccomerce.Domain.Core.Models;

public abstract class Entity<TKey>
{
    public TKey Id { get;  protected set; }

    private List<INotification> _domainEvents;
    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents = _domainEvents ?? new List<INotification>();
        _domainEvents.Add(eventItem);
    }

}
