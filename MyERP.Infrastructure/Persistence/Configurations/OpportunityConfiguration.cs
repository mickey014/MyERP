using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class OpportunityConfiguration : IEntityTypeConfiguration<Opportunity>
    {
        public void Configure(EntityTypeBuilder<Opportunity> builder)
        {
            builder.Property(o => o.Name).HasMaxLength(200).IsRequired();
            builder.Property(o => o.AssignedTo).HasMaxLength(450);
            builder.Property(o => o.Description).HasMaxLength(1000);

            builder.HasOne(o => o.Customer)
                .WithMany(c => c.Opportunities)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.OpportunityStage)
                .WithMany(s => s.Opportunities)
                .HasForeignKey(o => o.OpportunityStageID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
