using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class LeadStatusConfiguration : IEntityTypeConfiguration<LeadStatus>
    {
        public void Configure(EntityTypeBuilder<LeadStatus> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(30).IsRequired();
            builder.HasIndex(s => s.Name).IsUnique();

            // Section 24: New, Contacted, Qualified, Unqualified, Converted, Lost.
            builder.HasData(
                new LeadStatus { LeadStatusID = 1, Name = "New", SortOrder = 1 },
                new LeadStatus { LeadStatusID = 2, Name = "Contacted", SortOrder = 2 },
                new LeadStatus { LeadStatusID = 3, Name = "Qualified", SortOrder = 3 },
                new LeadStatus { LeadStatusID = 4, Name = "Unqualified", SortOrder = 4 },
                new LeadStatus { LeadStatusID = 5, Name = "Converted", SortOrder = 5 },
                new LeadStatus { LeadStatusID = 6, Name = "Lost", SortOrder = 6 }
            );
        }
    }
}
