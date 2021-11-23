using Moq;
using Moq.Protected;
using My.DDD.Tests.TestData;
using System.Threading.Tasks;
using Xunit;

namespace My.DDD.Tests
{
    public class BaseRepositoryTests
    {

        private readonly Mock<IDomainEventBus> _mockBus;
        private readonly Mock<BaseRepository<ExampleAggregate>> _mockRepository;

        private readonly BaseRepository<ExampleAggregate> _sut;

        public BaseRepositoryTests()
        {
            _mockBus = new Mock<IDomainEventBus>();
            _mockRepository = new Mock<BaseRepository<ExampleAggregate>>(_mockBus.Object);

            _sut = _mockRepository.Object;
        }

       
        [Fact]
        public async Task When_CreateAsync_Then_PerformCreateAsync_is_Called()
        {
            var testAggregate = new ExampleAggregate();

            _mockRepository
                .Protected()
                .Setup("PerformCreateAsync", ItExpr.IsAny<ExampleAggregate>())
                .Verifiable();

            await _sut.CreateAsync(testAggregate);

            _mockRepository
                .Protected()
                .Verify(
                    "PerformCreateAsync",
                    Times.Once(),
                    testAggregate);
        }

        [Fact]
        public async Task When_UpdateAsync_Then_PerformUpdateAsync_is_Called()
        {
            var testAggregate = new ExampleAggregate();

            _mockRepository
                .Protected()
                .Setup("PerformUpdateAsync", ItExpr.IsAny<ExampleAggregate>())
                .Verifiable();

            await _sut.UpdateAsync(testAggregate);

            _mockRepository
                .Protected()
                .Verify(
                    "PerformUpdateAsync",
                    Times.Once(),
                    testAggregate);
        }

        [Fact]
        public async Task When_DeleteAsync_Then_PerformDeleteAsync_is_Called()
        {
            var testAggregate = new ExampleAggregate();

            _mockRepository
                .Protected()
                .Setup("PerformDeleteAsync", ItExpr.IsAny<ExampleAggregate>())
                .Verifiable();

            await _sut.DeleteAsync(testAggregate);

            _mockRepository
                .Protected()
                .Verify(
                    "PerformDeleteAsync",
                    Times.Once(),
                    testAggregate);
        }
    }
}
