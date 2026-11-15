namespace MyERP.Infrastructure.Persistence.Entities
{
    /// <summary>Lookup table: Website, Referral, Walk-in, Social Media, etc.</summary>
    public class LeadSource
    {
        public int LeadSourceID { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public ICollection<Lead> Leads { get; set; } = new List<Lead>();
    }

}
