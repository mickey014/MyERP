namespace MyERP.Infrastructure.Persistence.Entities
{
    public class SaleReturnItem
    {
        public int SaleReturnItemID { get; set; }

        public int SaleReturnID { get; set; }
        public SaleReturn SaleReturn { get; set; } = null!;

        public long SaleItemID { get; set; }
        public SaleItem SaleItem { get; set; } = null!;

        public decimal Quantity { get; set; }

        public decimal RefundAmount { get; set; }
    }

}
