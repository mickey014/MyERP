using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class FollowUpConfiguration : IEntityTypeConfiguration<FollowUp>
    {
        public void Configure(EntityTypeBuilder<FollowUp> builder)
        {
            builder.Property(f => f.Notes).HasMaxLength(1000);
            builder.Property(f => f.AssignedTo).HasMaxLength(450);

            builder.HasOne(f => f.Customer)
                .WithMany(c => c.FollowUps)
                .HasForeignKey(f => f.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Lead)
                .WithMany(l => l.FollowUps)
                .HasForeignKey(f => f.LeadID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Opportunity)
                .WithMany(o => o.FollowUps)
                .HasForeignKey(f => f.OpportunityID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(f => f.DueDate);
        }
    }
}
