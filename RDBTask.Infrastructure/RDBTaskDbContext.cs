namespace RDBTask.Infrastructure;

using Microsoft.EntityFrameworkCore;
using RDBTask.Domain.AggregatesModel.OrderAggregate;
using RDBTask.Domain.AggregatesModel.ProviderAggregate;
using RDBTask.Domain.SeedWork;
using RDBTask.Infrastructure.EntityConfigurations;

public class RDBTaskDbContext : DbContext, IUnitOfWork
{
    public const string DEFAULT_SCHEMA = "dbo";
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public RDBTaskDbContext(DbContextOptions<RDBTaskDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProviderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemEntityTypeConfiguration());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        return true;
    }
}