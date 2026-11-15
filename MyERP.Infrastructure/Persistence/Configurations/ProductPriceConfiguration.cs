using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
    {
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            builder.HasOne(pp => pp.Product)
                .WithMany(p => p.PriceHistory)
                .HasForeignKey(pp => pp.ProductID)
                .OnDelete(DeleteBehavior.Cascade); // price history is owned by the product
        }
    }
}
