namespace My.DDD.Exceptions
{
    public class NotFoundException<TAggregate> : Exception where TAggregate : Aggregate
    {
        override public string Message => $"{typeof(TAggregate).FullName} was not found.";
    }
}
