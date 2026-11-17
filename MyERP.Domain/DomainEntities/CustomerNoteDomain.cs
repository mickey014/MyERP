namespace MyERP.Domain.DomainEntities
{
    public class CustomerNoteDomain
    {
        public int CustomerNoteID { get; set; }
        public int CustomerID { get; set; }
        public string Note { get; set; } = string.Empty;
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
