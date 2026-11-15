using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class SaleReturnItemConfiguration : IEntityTypeConfiguration<SaleReturnItem>
    {
        public void Configure(EntityTypeBuilder<SaleReturnItem> builder)
        {
            builder.HasOne(ri => ri.SaleReturn)
                .WithMany(r => r.SaleReturnItems)
                .HasForeignKey(ri => ri.SaleReturnID)
                .OnDelete(DeleteBehavior.Cascade); // line items are owned by the return

            builder.HasOne(ri => ri.SaleItem)
                .WithMany(si => si.SaleReturnItems)
                .HasForeignKey(ri => ri.SaleItemID)
                .OnDelete(DeleteBehavior.Restrict); // a returned line item can't be cascade-deleted out from under the return
        }
    }
}
