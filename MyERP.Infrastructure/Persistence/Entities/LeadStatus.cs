namespace MyERP.Infrastructure.Persistence.Entities
{
    /// <summary>Lookup table: New, Contacted, Qualified, Unqualified, Converted, Lost.</summary>
    public class LeadStatus
    {
        public int LeadStatusID { get; set; }

        public string Name { get; set; } = string.Empty;

        /// <summary>Display order on the pipeline / status dropdown.</summary>
        public int SortOrder { get; set; }

        public ICollection<Lead> Leads { get; set; } = new List<Lead>();
    }
}
