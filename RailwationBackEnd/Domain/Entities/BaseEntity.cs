namespace Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; init; }
    public bool IsDeleted { get; set; }
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}
