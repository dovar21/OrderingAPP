namespace RDBTask.Domain.AggregatesModel.ProviderAggregate;

using RDBTask.Domain.SeedWork;

public interface IProviderRepository : IRepository<Provider>
{
    Task<Provider> FindAsync(int id);
    Task<List<Provider>> ToListAsync();
}

