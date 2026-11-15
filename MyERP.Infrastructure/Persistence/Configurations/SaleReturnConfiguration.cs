using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class SaleReturnConfiguration : IEntityTypeConfiguration<SaleReturn>
    {
        public void Configure(EntityTypeBuilder<SaleReturn> builder)
        {
            builder.Property(r => r.Reason).HasMaxLength(500);
            builder.Property(r => r.CreatedBy).HasMaxLength(450);

            // Restrict (not Cascade) here is what keeps SaleReturnItem's
            // FK to SaleItem below from creating a second cascade path
            // back to the same Sale — SQL Server forbids a table being
            // reachable through two different cascade routes.
            builder.HasOne(r => r.Sale)
                .WithMany(s => s.SaleReturns)
                .HasForeignKey(r => r.SaleID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
