namespace My.DDD
{
    public static class AggregateExtensions
    {
        public static Task<TAggregate> ErrorWhenNotFound<TAggregate>(this Task<TAggregate> task)
        {
            if (task.Result == null) throw new Exception($"{typeof(TAggregate).FullName} was not found");

            return task;
        }

        public static TAggregate ErrorWhenNotFound<TAggregate>(this TAggregate aggregate)
        {
            if (aggregate == null) throw new Exception($"{typeof(TAggregate).FullName} was not found");

            return aggregate;
        }
    }
}
