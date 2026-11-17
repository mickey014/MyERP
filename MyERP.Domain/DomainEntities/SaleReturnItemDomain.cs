namespace MyERP.Domain.DomainEntities
{
    public class SaleReturnItemDomain
    {
        public int SaleReturnItemID { get; set; }
        public int SaleReturnID { get; set; }
        public long SaleItemID { get; set; }
        public decimal Quantity { get; set; }
        public decimal RefundAmount { get; set; }
    }

}
