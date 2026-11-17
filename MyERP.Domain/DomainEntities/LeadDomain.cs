namespace MyERP.Domain.DomainEntities
{
    public class LeadDomain
    {
        public int LeadID { get; set; }
        public int? CustomerID { get; set; }
        public string LeadName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? LeadSourceID { get; set; }
        public int LeadStatusID { get; set; }
        public string? AssignedTo { get; set; }
        public decimal? EstimatedValue { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
