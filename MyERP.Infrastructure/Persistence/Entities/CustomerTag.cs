namespace MyERP.Infrastructure.Persistence.Entities
{
    public class CustomerTag
    {
        public int CustomerID { get; set; }
        public Customer Customer { get; set; } = null!;

        public int TagID { get; set; }
        public Tag Tag { get; set; } = null!;
    }
}
