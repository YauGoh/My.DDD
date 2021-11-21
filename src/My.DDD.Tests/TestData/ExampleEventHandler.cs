using System.Threading.Tasks;

namespace My.DDD.Tests.TestData
{
    public class ExampleEventHandler : IEventHandler<ExampleEvent>
    {
        public Task HandleAsync(ExampleEvent @event) => Task.CompletedTask;
    }
}
