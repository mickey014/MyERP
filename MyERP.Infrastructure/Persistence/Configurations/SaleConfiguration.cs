using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(s => s.InvoiceNumber).HasMaxLength(40).IsRequired();
            builder.Property(s => s.CashierUserID).HasMaxLength(450);
            builder.Property(s => s.Status).HasConversion<string>().HasMaxLength(20);

            // Section 40: index InvoiceNumber.
            builder.HasIndex(s => s.InvoiceNumber).IsUnique();

            builder.HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerID)
                .OnDelete(DeleteBehavior.Restrict); // never let a customer delete take sales history with it

            // Sale -> SaleItems and Sale -> Payments are configured from
            // the child side (SaleItemConfiguration, PaymentConfiguration)
            // to keep each relationship defined in exactly one place.
        }
    }
}
