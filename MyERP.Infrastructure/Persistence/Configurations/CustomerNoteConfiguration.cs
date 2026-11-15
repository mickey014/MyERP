using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class CustomerNoteConfiguration : IEntityTypeConfiguration<CustomerNote>
    {
        public void Configure(EntityTypeBuilder<CustomerNote> builder)
        {
            builder.Property(n => n.Note).HasMaxLength(2000).IsRequired();
            builder.Property(n => n.CreatedBy).HasMaxLength(450); // matches Identity's key length

            builder.HasOne(n => n.Customer)
                .WithMany(c => c.Notes)
                .HasForeignKey(n => n.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
