using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Orders;

namespace Persistence.Data.Configuration.Orders;

public class OrderDetailConfigiration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetails");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.OrderId)
           .IsRequired();
        builder.Property(x => x.ProductId)
           .IsRequired();

        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderDetails)
            .HasForeignKey(x => x.OrderId);

        builder.HasOne(x => x.Product)
           .WithMany(x => x.OrderDetails)
           .HasForeignKey(x => x.ProductId);
    }
}
