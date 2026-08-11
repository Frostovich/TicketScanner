namespace TicketScanner.Domain.MainEntity;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    protected Entity(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id не может быть пустым.", nameof(id));
        
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other)
            return false;
        if (ReferenceEquals(this, other))
            return true;
        if (GetType() != obj.GetType())
            return false;
        
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    protected Entity()
    {
       
    }
}
