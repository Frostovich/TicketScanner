using TicketScanner.Domain.MainEntity;

namespace TicketScanner.Domain.AggregateRoot;

public interface IAggregateRoot {};

public interface IDomainEvent { };
public abstract class AggregateRoot : Entity, IAggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = new();
    protected AggregateRoot(Guid id) : base(id)
    {
    }


    protected AggregateRoot()
    {
    }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

}