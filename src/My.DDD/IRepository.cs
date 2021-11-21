namespace My.DDD
{
    public interface IRepository<TAggregate> where TAggregate : Aggregate
    {
        Task CreateAsync(TAggregate aggregate);
        Task<TAggregate?> ReadAsync(Guid id);
        Task UpdateAsync(TAggregate aggregate);
        Task DeleteAsync(TAggregate aggregate);
    }
}
