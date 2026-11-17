namespace MyERP.Domain.DomainEntities
{
    public class FollowUpDomain
    {
        public int FollowUpID { get; set; }

        public int? CustomerID { get; set; }

        public int? LeadID { get; set; }

        public int? OpportunityID { get; set; }

        public DateTime DueDate { get; set; }

        public string? Notes { get; set; }

        public string? AssignedTo { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public void Complete()
        {
            IsCompleted = true;
        }
        public void Reopen()
        {
            IsCompleted = false;
        }
    }

}
