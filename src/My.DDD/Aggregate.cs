namespace My.DDD
{
    public abstract class Aggregate : Entity
    {
        private List<IEvent> _events = new List<IEvent>();

        public IReadOnlyList<IEvent> RaisedEvents => _events;

        /// <summary>
        /// Raises and event that will be published when the Aggregate is persisted by the 
        /// Repository via a call to CreateAsync or UpdateAsync.
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event"></param>
        protected void Raise<TEvent>(TEvent @event) where TEvent : IEvent => _events.Add(@event);

        public void ClearRaisedEvents() => _events.Clear();
    }
}
