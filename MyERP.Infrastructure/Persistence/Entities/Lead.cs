namespace MyERP.Infrastructure.Persistence.Entities
{
    public class Lead
    {
        public int LeadID { get; set; }

        /// <summary>
        /// Nullable: a lead commonly arrives before any Customer record
        /// exists and only gets linked once qualified/converted.
        /// </summary>
        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }

        public string LeadName { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? LeadSourceID { get; set; }
        public LeadSource? LeadSource { get; set; }

        public int LeadStatusID { get; set; }
        public LeadStatus LeadStatus { get; set; } = null!;

        /// <summary>ApplicationUser.Id of the salesperson this lead is assigned to.</summary>
        public string? AssignedTo { get; set; }

        public decimal? EstimatedValue { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public ICollection<FollowUp> FollowUps { get; set; } = new List<FollowUp>();
    }

}
