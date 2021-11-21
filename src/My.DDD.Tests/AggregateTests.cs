using FluentAssertions;
using My.DDD.Tests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace My.DDD.Tests
{
    public class AggregateTests
    {
        [Fact]
        public void Aggregates_Can_Raise_Events()
        {
            var testAggregates = new ExampleAggregate();

            testAggregates.DoSomethingThatRaisesAnExampleEvent();

            testAggregates.RaisedEvents.Should().Contain(e => (e as ExampleEvent)!.ExampleAggregateId == testAggregates.Id);
        }

        [Fact]
        public void Aggregates_Have_Auto_Generated_Id()
        {
            var testAggregate = new ExampleAggregate();

            testAggregate.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void When_ClearEvents_Then_All_Events_Are_Removed()
        {
            var testAggregates = new ExampleAggregate();

            testAggregates.DoSomethingThatRaisesAnExampleEvent();

            testAggregates.ClearRaisedEvents();

            testAggregates.RaisedEvents.Should().BeEmpty();
        }
    }
}
