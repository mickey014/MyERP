using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Persistence.Configurations
{
    public class ActivityTypeConfiguration : IEntityTypeConfiguration<ActivityType>
    {
        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {
            builder.Property(t => t.Name).HasMaxLength(30).IsRequired();
            builder.HasIndex(t => t.Name).IsUnique();

            // Section 26: Call, Email, Meeting, Demo, Follow-up, SMS, Visit.
            builder.HasData(
                new ActivityType { ActivityTypeID = 1, Name = "Call" },
                new ActivityType { ActivityTypeID = 2, Name = "Email" },
                new ActivityType { ActivityTypeID = 3, Name = "Meeting" },
                new ActivityType { ActivityTypeID = 4, Name = "Demo" },
                new ActivityType { ActivityTypeID = 5, Name = "Follow-up" },
                new ActivityType { ActivityTypeID = 6, Name = "SMS" },
                new ActivityType { ActivityTypeID = 7, Name = "Visit" }
            );
        }
    }
}
