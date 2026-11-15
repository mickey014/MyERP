namespace MyERP.Infrastructure.Persistence.Entities
{
    /// <summary>High-volume transactional table — bigint key (Section 41).</summary>
    public class SaleItem
    {
        public long SaleItemID { get; set; }

        public long SaleID { get; set; }
        public Sale Sale { get; set; } = null!;

        public int ProductID { get; set; }
        public Product Product { get; set; } = null!;

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal LineTotal { get; set; }

        public ICollection<SaleReturnItem> SaleReturnItems { get; set; } = new List<SaleReturnItem>();
    }

}
