using System.Threading.Tasks;

namespace My.DDD.Tests.TestData
{
    public class ExampleEventHandler : IDomainEventHandler<ExampleEvent>
    {
        public Task HandleAsync(ExampleEvent @event) => Task.CompletedTask;
    }
}
