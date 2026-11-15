using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class CustomerTagConfiguration : IEntityTypeConfiguration<CustomerTag>
    {
        public void Configure(EntityTypeBuilder<CustomerTag> builder)
        {
            builder.HasKey(ct => new { ct.CustomerID, ct.TagID });

            builder.HasOne(ct => ct.Customer)
                .WithMany(c => c.CustomerTags)
                .HasForeignKey(ct => ct.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ct => ct.Tag)
                .WithMany(t => t.CustomerTags)
                .HasForeignKey(ct => ct.TagID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
