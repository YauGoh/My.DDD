namespace My.DDD
{
    public abstract class Aggregate : Entity
    {
        private List<IDomainEvent> _events = new List<IDomainEvent>();

        public IReadOnlyList<IDomainEvent> RaisedEvents => _events;

        /// <summary>
        /// Raises and event that will be published when the Aggregate is persisted by the 
        /// Repository via a call to CreateAsync or UpdateAsync.
        /// </summary>
        /// <typeparam name="TDomainEvent"></typeparam>
        /// <param name="event"></param>
        protected void Raise<TDomainEvent>(TDomainEvent @event) where TDomainEvent : IDomainEvent => _events.Add(@event);

        public void ClearRaisedEvents() => _events.Clear();
    }
}
