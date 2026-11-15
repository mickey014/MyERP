namespace MyERP.Infrastructure.Persistence.Entities
{
    public class SaleReturn
    {
        public int SaleReturnID { get; set; }

        public long SaleID { get; set; }
        public Sale Sale { get; set; } = null!;

        public DateTime ReturnDate { get; set; } = DateTime.UtcNow;

        public string? Reason { get; set; }

        public decimal TotalRefundAmount { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<SaleReturnItem> SaleReturnItems { get; set; } = new List<SaleReturnItem>();
    }
}
