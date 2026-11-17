namespace MyERP.Infrastructure.Persistence.Entities
{
    public class OpportunityStage
    {
        public int OpportunityStageID { get; set; }

        public string Name { get; set; } = string.Empty;

        /// <summary>Position on the visual pipeline board.</summary>
        public int SortOrder { get; set; }

        public ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
    }

}
