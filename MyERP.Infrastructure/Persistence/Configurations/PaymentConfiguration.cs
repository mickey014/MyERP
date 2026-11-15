using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.ReferenceNumber).HasMaxLength(100);

            builder.HasOne(p => p.Sale)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.SaleID)
                .OnDelete(DeleteBehavior.Cascade); // payments are owned by the sale

            builder.HasOne(p => p.PaymentMethod)
                .WithMany(pm => pm.Payments)
                .HasForeignKey(p => p.PaymentMethodID)
                .OnDelete(DeleteBehavior.Restrict); // keep a payment method you can't delete while in use
        }
    }
}
