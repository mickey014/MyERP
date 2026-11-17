namespace MyERP.Domain.DomainEntities
{
    public class CustomerContactDomain
    {
        public int CustomerContactID { get; set; }

        public int CustomerID { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? Title { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public bool IsPrimary { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
