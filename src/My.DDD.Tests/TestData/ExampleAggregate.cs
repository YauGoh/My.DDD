namespace My.DDD.Tests.TestData
{
    public class ExampleAggregate : Aggregate
    {
        public void DoSomethingThatRaisesAnExampleEvent()
        {
            Raise(new ExampleEvent(Id));
        }
    }
}
