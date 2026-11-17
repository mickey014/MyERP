
namespace MyERP.Domain.DomainEntities
{
    public class OpportunityDomain
    {
        public int OpportunityID { get; set; }
        public int CustomerID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int OpportunityStageID { get; set; }
        public decimal EstimatedValue { get; set; }
        public DateTime? ExpectedCloseDate { get; set; }
        public string? AssignedTo { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
