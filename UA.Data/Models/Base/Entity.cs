namespace UA.Data.Models.Base;

public abstract class Entity
{
}

public abstract class Entity<TId> : Entity
    where TId : struct
{
    public TId Id { get; set; }
}