using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration.Products;

public class ProductFeaturesConfiguration : IEntityTypeConfiguration<ProductFeatures>
{
    public void Configure(EntityTypeBuilder<ProductFeatures> builder)
    {
        builder.ToTable("ProductFeatures");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductFeatures)
            .HasForeignKey(x => x.ProductId);
    }
}
