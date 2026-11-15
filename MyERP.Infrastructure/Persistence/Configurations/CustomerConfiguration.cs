using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.CustomerCode).HasMaxLength(30).IsRequired();
            builder.Property(c => c.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.CompanyName).HasMaxLength(150);
            builder.Property(c => c.Email).HasMaxLength(256);
            builder.Property(c => c.Phone).HasMaxLength(30);
            builder.Property(c => c.Address).HasMaxLength(300);
            builder.Property(c => c.City).HasMaxLength(100);

            // Section 40: index CustomerCode, Email, Phone for fast lookup.
            builder.HasIndex(c => c.CustomerCode).IsUnique();
            builder.HasIndex(c => c.Email);
            builder.HasIndex(c => c.Phone);
        }
    }
}
