using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class InventoryTransactionConfiguration : IEntityTypeConfiguration<InventoryTransaction>
    {
        public void Configure(EntityTypeBuilder<InventoryTransaction> builder)
        {
            builder.Property(t => t.TransactionType).HasConversion<string>().HasMaxLength(20);
            builder.Property(t => t.ReferenceNumber).HasMaxLength(50);
            builder.Property(t => t.Remarks).HasMaxLength(500);
            builder.Property(t => t.CreatedBy).HasMaxLength(450);

            builder.HasOne(t => t.Product)
                .WithMany(p => p.InventoryTransactions)
                .HasForeignKey(t => t.ProductID)
                .OnDelete(DeleteBehavior.Restrict); // preserve the stock movement history

            builder.HasIndex(t => t.ProductID);
            builder.HasIndex(t => t.TransactionDate);
        }
    }
}
