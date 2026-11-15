namespace MyERP.Infrastructure.Persistence.Entities
{
    /// <summary>A reusable label (e.g. "VIP", "Wholesale") that can be attached to customers.</summary>
    public class Tag
    {
        public int TagID { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<CustomerTag> CustomerTags { get; set; } = new List<CustomerTag>();
    }

}
