using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class OpportunityStageConfiguration : IEntityTypeConfiguration<OpportunityStage>
    {
        public void Configure(EntityTypeBuilder<OpportunityStage> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(30).IsRequired();
            builder.HasIndex(s => s.Name).IsUnique();

            // Section 25: New, Qualified, Proposal, Negotiation, Won, Lost.
            builder.HasData(
                new OpportunityStage { OpportunityStageID = 1, Name = "New", SortOrder = 1 },
                new OpportunityStage { OpportunityStageID = 2, Name = "Qualified", SortOrder = 2 },
                new OpportunityStage { OpportunityStageID = 3, Name = "Proposal", SortOrder = 3 },
                new OpportunityStage { OpportunityStageID = 4, Name = "Negotiation", SortOrder = 4 },
                new OpportunityStage { OpportunityStageID = 5, Name = "Won", SortOrder = 5 },
                new OpportunityStage { OpportunityStageID = 6, Name = "Lost", SortOrder = 6 }
            );
        }
    }
}
