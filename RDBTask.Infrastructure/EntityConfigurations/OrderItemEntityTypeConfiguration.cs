namespace RDBTask.Infrastructure.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RDBTask.Domain.AggregatesModel.OrderAggregate;

class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> config)
    {
        config.ToTable("OrderItems", RDBTaskDbContext.DEFAULT_SCHEMA);

        config.HasKey(o => o.Id);

        config.Property(e => e.Name)
            .IsRequired();

        config.Property(e => e.Quantity)
            .IsRequired()
            .HasPrecision(18, 3);

        config.Property(e => e.Unit)
            .IsRequired();
    }
}
