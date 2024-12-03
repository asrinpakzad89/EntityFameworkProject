using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title)
            .IsRequired();
        builder.Property(x => x.Title)
            .HasMaxLength(150);
        builder.Property(x => x.Price)
           .IsRequired();
        builder.Property(x => x.Count)
           .HasDefaultValue(0);

        builder.HasMany(x => x.OrderDetails)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
    }
}
