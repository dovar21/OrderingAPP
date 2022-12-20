namespace RDBTask.Infrastructure.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDBTask.Domain.AggregatesModel.ProviderAggregate;

class ProviderEntityTypeConfiguration : IEntityTypeConfiguration<Provider>
{
    public void Configure(EntityTypeBuilder<Provider> config)
    {
        config.ToTable("Providers", RDBTaskDbContext.DEFAULT_SCHEMA);

        config.HasKey(b => b.Id);

        config.Property(b => b.Id);

        config.Property(b => b.Name)
            .IsRequired();
    }
}