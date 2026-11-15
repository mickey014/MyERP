using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class CustomerContactConfiguration : IEntityTypeConfiguration<CustomerContact>
    {
        public void Configure(EntityTypeBuilder<CustomerContact> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Title).HasMaxLength(100);
            builder.Property(c => c.Email).HasMaxLength(256);
            builder.Property(c => c.Phone).HasMaxLength(30);

            // A contact is owned by its customer — deleting the customer
            // deletes its contacts too.
            builder.HasOne(c => c.Customer)
                .WithMany(cust => cust.Contacts)
                .HasForeignKey(c => c.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
