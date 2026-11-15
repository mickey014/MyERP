namespace MyERP.Infrastructure.Persistence.Entities
{
    public class Activity
    {
        public long ActivityID { get; set; }

        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public int? LeadID { get; set; }
        public Lead? Lead { get; set; }

        public int? OpportunityID { get; set; }
        public Opportunity? Opportunity { get; set; }

        public int ActivityTypeID { get; set; }
        public ActivityType ActivityType { get; set; } = null!;

        public string Subject { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime ActivityDate { get; set; } = DateTime.UtcNow;

        /// <summary>ApplicationUser.Id of whoever owns this activity.</summary>
        public string? AssignedTo { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
