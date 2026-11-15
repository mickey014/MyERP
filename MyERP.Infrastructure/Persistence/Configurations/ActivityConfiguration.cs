using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.Property(a => a.Subject).HasMaxLength(200).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(1000);
            builder.Property(a => a.AssignedTo).HasMaxLength(450);

            // All three links are optional and independently Restrict —
            // an activity can outlive none of them being deleted out
            // from under it, and none of these chains overlap with each
            // other so there's no multiple-cascade-path conflict.
            builder.HasOne(a => a.Customer)
                .WithMany(c => c.Activities)
                .HasForeignKey(a => a.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Lead)
                .WithMany(l => l.Activities)
                .HasForeignKey(a => a.LeadID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Opportunity)
                .WithMany(o => o.Activities)
                .HasForeignKey(a => a.OpportunityID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.ActivityType)
                .WithMany(t => t.Activities)
                .HasForeignKey(a => a.ActivityTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.ActivityDate);
        }
    }
}
