namespace RecurrenceHub.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; private init; }

    protected readonly ICollection<IDomainEvent> _domainEvents = [];

    protected Entity() { }
    protected Entity(Guid id)
    {
        Id = id;
    }

    public ICollection<IDomainEvent> PopDomainEvents()
    {
        var copy = _domainEvents.ToList();
        _domainEvents.Clear();

        return copy;
    }
}