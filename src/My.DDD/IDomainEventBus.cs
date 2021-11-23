namespace My.DDD
{
    public interface IDomainEventBus
    {
        Task PublishAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent;
    }
}
