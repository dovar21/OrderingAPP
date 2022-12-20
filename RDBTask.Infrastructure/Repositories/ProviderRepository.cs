namespace RDBTask.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using RDBTask.Domain.AggregatesModel.ProviderAggregate;
using RDBTask.Domain.SeedWork;

public class ProviderRepository: IProviderRepository
{
    private readonly RDBTaskDbContext _context;

    public IUnitOfWork UnitOfWork
    {
        get
        {
            return _context;
        }
    }

    public ProviderRepository(RDBTaskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Provider> FindAsync(int id)
    {
        return await _context.Providers.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<List<Provider>> ToListAsync()
    {
        return await _context
                            .Providers.ToListAsync();
    }
}