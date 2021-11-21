namespace My.DDD
{
    public abstract class BaseRepository<TAggregate> : IRepository<TAggregate> where TAggregate : Aggregate
    {
        private readonly IEventBus _eventBus;

        public BaseRepository(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task CreateAsync(TAggregate aggregate)
        {
            await PerformCreateAsync(aggregate);

            await DispatchRaisedEvents(aggregate);
        }

        public async Task DeleteAsync(TAggregate aggregate)
        {
            await PerformDeleteAsync(aggregate);

            await DispatchRaisedEvents(aggregate);
        }

        public abstract Task<TAggregate?> ReadAsync(Guid id);

        public async Task UpdateAsync(TAggregate aggregate)
        {
            await PerformUpdateAsync(aggregate);

            await DispatchRaisedEvents(aggregate);
        }

        protected abstract Task PerformCreateAsync(TAggregate aggregate);

        protected abstract Task PerformUpdateAsync(TAggregate aggregate);

        protected abstract Task PerformDeleteAsync(TAggregate aggregate);

        private async Task DispatchRaisedEvents(TAggregate aggregate)
        {
            var tasks = aggregate.RaisedEvents.Select(@event => (Task)Publish((dynamic)@event));

            await Task.WhenAll(tasks);

            aggregate.ClearRaisedEvents();
        }

        private Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            return _eventBus.PublishAsync(@event);
        }
    }
}
