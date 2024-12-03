using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired();
        builder.Property(x => x.Name)
            .HasMaxLength(150);
        builder.Property(x => x.Price)
           .IsRequired();
        builder.Property(x => x.ViewCount)
           .HasDefaultValue(0);

        builder.HasOne(x => x.Category).
            WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);

        builder.HasMany(x => x.ProductFeatures)
           .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);

        builder.HasMany(x => x.ProductImages)
           .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);

        builder.HasMany(x => x.OrderDetails)
            .WithOne(x => x.Product)
             .HasForeignKey(x => x.ProductId);

        builder.HasMany(x => x.CartItems)
            .WithOne(x => x.Product)
             .HasForeignKey(x => x.ProductId);
    }
}
