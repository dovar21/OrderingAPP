namespace RDBTask.Infrastructure.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDBTask.Domain.AggregatesModel.OrderAggregate;
using RDBTask.Domain.AggregatesModel.ProviderAggregate;

class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> config)
    {
        config.ToTable("Orders", RDBTaskDbContext.DEFAULT_SCHEMA);

        config.HasKey(o => o.Id);

        config.Property(e => e.Number)
            .IsRequired();

        config.Property(e => e.OrderDate)
            .IsRequired();

        config.Property(e => e.ProviderId)
            .IsRequired();

        var navigation = config.Metadata.FindNavigation(nameof(Order.OrderItems));

        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        config.HasOne<Provider>()
            .WithMany()
            .IsRequired()
            .HasForeignKey("ProviderId");
    }
}