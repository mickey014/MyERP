namespace MyERP.Domain.DomainEntities
{
    public class ActivityDomain
    {
        public long ActivityID { get; set; }

        public int? CustomerID { get; set; }

        public int? LeadID { get; set; }

        public int? OpportunityID { get; set; }

        public int ActivityTypeID { get; set; }

        public string Subject { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsCompleted { get; private set; }

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
