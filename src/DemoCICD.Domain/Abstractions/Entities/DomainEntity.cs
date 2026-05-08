namespace DemoCICD.Domain.Abstractions.Entities;
public abstract class DomainEntity<TKey>
{
    public virtual TKey Id { get; set; }

}
