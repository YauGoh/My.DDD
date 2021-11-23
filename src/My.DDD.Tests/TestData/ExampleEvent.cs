using System;

namespace My.DDD.Tests.TestData
{
    public record ExampleEvent(Guid ExampleAggregateId) : IDomainEvent;
}
