using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class LeadSourceConfiguration : IEntityTypeConfiguration<LeadSource>
    {
        public void Configure(EntityTypeBuilder<LeadSource> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(s => s.Name).IsUnique();

            builder.HasData(
                new LeadSource { LeadSourceID = 1, Name = "Website", IsActive = true },
                new LeadSource { LeadSourceID = 2, Name = "Referral", IsActive = true },
                new LeadSource { LeadSourceID = 3, Name = "Walk-in", IsActive = true },
                new LeadSource { LeadSourceID = 4, Name = "Social Media", IsActive = true }
            );
        }
    }
}
