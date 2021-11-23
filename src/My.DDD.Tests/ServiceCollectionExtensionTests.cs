using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using My.DDD.Tests.TestData;
using System.Reflection;
using Xunit;

namespace My.DDD.Tests
{
    public class ServiceCollectionExtensionTests
    {
        [Fact]
        public void When_AddDomainEvents_Then_All_Handlers_Are_Registered()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDomainEvents(Assembly.GetExecutingAssembly());

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var handler = serviceProvider.GetRequiredService<IDomainEventHandler<ExampleEvent>>();

            handler.Should().BeOfType<ExampleEventHandler>();
        }
    }
}
