namespace MyERP.Domain.DomainEntities
{
    public class SaleItemDomain
    {
        public long SaleItemID { get; set; }
        public long SaleID { get; set; }
        public int ProductID { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal LineTotal { get; set; }
    }

}
