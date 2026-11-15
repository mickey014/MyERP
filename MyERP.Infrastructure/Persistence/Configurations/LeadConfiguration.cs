using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.Property(l => l.LeadName).HasMaxLength(150).IsRequired();
            builder.Property(l => l.Email).HasMaxLength(256);
            builder.Property(l => l.Phone).HasMaxLength(30);
            builder.Property(l => l.AssignedTo).HasMaxLength(450);

            builder.HasOne(l => l.Customer)
                .WithMany(c => c.Leads)
                .HasForeignKey(l => l.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.LeadSource)
                .WithMany(s => s.Leads)
                .HasForeignKey(l => l.LeadSourceID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.LeadStatus)
                .WithMany(s => s.Leads)
                .HasForeignKey(l => l.LeadStatusID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
