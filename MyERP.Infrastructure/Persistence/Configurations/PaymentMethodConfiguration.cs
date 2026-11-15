using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;


namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();

            // Section 13: Cash, GCash, Card.
            builder.HasData(
                new PaymentMethod { PaymentMethodID = 1, Name = "Cash", IsActive = true },
                new PaymentMethod { PaymentMethodID = 2, Name = "GCash", IsActive = true },
                new PaymentMethod { PaymentMethodID = 3, Name = "Card", IsActive = true }
            );
        }
    }
}