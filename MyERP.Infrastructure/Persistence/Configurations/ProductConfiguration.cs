using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.SKU).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Barcode).HasMaxLength(50);
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000);

            // Section 40: index SKU and Barcode. SQL Server allows
            // multiple NULLs through a unique index, so a nullable,
            // not-always-populated Barcode can still be unique.
            builder.HasIndex(p => p.SKU).IsUnique();
            builder.HasIndex(p => p.Barcode).IsUnique();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Restrict); // don't let a category with products be deleted

            builder.HasOne(p => p.Inventory)
                .WithOne(i => i.Product)
                .HasForeignKey<Inventory>(i => i.ProductID)
                .OnDelete(DeleteBehavior.Cascade); // the inventory row has no meaning without its product
        }
    }
}
