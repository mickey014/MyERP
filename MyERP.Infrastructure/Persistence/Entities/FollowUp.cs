namespace MyERP.Infrastructure.Persistence.Entities
{
    public class FollowUp
    {
        public int FollowUpID { get; set; }

        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public int? LeadID { get; set; }
        public Lead? Lead { get; set; }

        public int? OpportunityID { get; set; }
        public Opportunity? Opportunity { get; set; }

        public DateTime DueDate { get; set; }

        public string? Notes { get; set; }

        /// <summary>ApplicationUser.Id of whoever owns this follow-up.</summary>
        public string? AssignedTo { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
