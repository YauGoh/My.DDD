using Moq;
using My.DDD.Tests.TestData;
using System.Threading.Tasks;
using Xunit;

namespace My.DDD.Tests
{
    public class BaseRepositoryEventBusTests
    {
        private readonly Mock<IDomainEventBus> _mockBus;
        private readonly Mock<BaseRepository<ExampleAggregate>> _mockRepository;

        private readonly BaseRepository<ExampleAggregate> _sut;

        public BaseRepositoryEventBusTests()
        {
            _mockBus = new Mock<IDomainEventBus>();
            _mockRepository = new Mock<BaseRepository<ExampleAggregate>>(_mockBus.Object);

            _sut = _mockRepository.Object;
        }

        [Fact]
        public async Task Given_Aggregate_Has_Raised_Events_When_CreateAsync_Is_Called_Events_Are_Dispatched()
        {
            var testAggregates = new ExampleAggregate();

            testAggregates.DoSomethingThatRaisesAnExampleEvent();

            await _sut.CreateAsync(testAggregates);

            _mockBus.Verify(_ => _.PublishAsync(It.Is<ExampleEvent>(e => e.ExampleAggregateId == testAggregates.Id)));
        }

        [Fact]
        public async Task Given_Aggregate_Has_Raised_Events_When_UpdateAsync_Is_Called_Events_Are_Dispatched()
        {
            var testAggregates = new ExampleAggregate();

            testAggregates.DoSomethingThatRaisesAnExampleEvent();

            await _sut.UpdateAsync(testAggregates);

            _mockBus.Verify(_ => _.PublishAsync(It.Is<ExampleEvent>(e => e.ExampleAggregateId == testAggregates.Id)));
        }

        [Fact]
        public async Task Given_Aggregate_Has_Raised_Events_When_DeleteAsync_Is_Called_Events_Are_Dispatched()
        {
            var testAggregates = new ExampleAggregate();

            testAggregates.DoSomethingThatRaisesAnExampleEvent();

            await _sut.DeleteAsync(testAggregates);

            _mockBus.Verify(_ => _.PublishAsync(It.Is<ExampleEvent>(e => e.ExampleAggregateId == testAggregates.Id)));
        }
    }
}
