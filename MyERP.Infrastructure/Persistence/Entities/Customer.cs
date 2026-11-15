namespace MyERP.Infrastructure.Persistence.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string CustomerCode { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        /// <summary>Optional — set for B2B customers.</summary>
        public string? CompanyName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public ICollection<CustomerContact> Contacts { get; set; } = new List<CustomerContact>();
        public ICollection<CustomerNote> Notes { get; set; } = new List<CustomerNote>();
        public ICollection<CustomerTag> CustomerTags { get; set; } = new List<CustomerTag>();
        public ICollection<Lead> Leads { get; set; } = new List<Lead>();
        public ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
        public ICollection<FollowUp> FollowUps { get; set; } = new List<FollowUp>();
    }

}
