
namespace MyERP.Domain.DomainEntities
{
    public class LeadStatusDomain
    {
        public int LeadStatusID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SortOrder { get; set; }
    }
}
