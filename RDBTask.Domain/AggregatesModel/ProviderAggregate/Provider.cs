namespace RDBTask.Domain.AggregatesModel.ProviderAggregate;

using RDBTask.Domain.SeedWork;

public class Provider: Entity, IAggregateRoot
{
    public string Name { get; private set; }
}