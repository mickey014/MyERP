
namespace MyERP.Infrastructure.Persistence.Entities
{
    public class Opportunity
    {
        public int OpportunityID { get; set; }

        /// <summary>
        /// Required: unlike a Lead, an Opportunity represents a
        /// qualified deal already tied to a known Customer record.
        /// </summary>
        public int CustomerID { get; set; }
        public Customer Customer { get; set; } = null!;

        public string Name { get; set; } = string.Empty;

        public int OpportunityStageID { get; set; }
        public OpportunityStage OpportunityStage { get; set; } = null!;

        public decimal EstimatedValue { get; set; }

        public DateTime? ExpectedCloseDate { get; set; }

        /// <summary>ApplicationUser.Id of the salesperson this opportunity is assigned to.</summary>
        public string? AssignedTo { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public ICollection<FollowUp> FollowUps { get; set; } = new List<FollowUp>();
    }

}
