namespace MyERP.Domain.DomainEntities
{
    public class SaleReturnDomain
    {
        public int SaleReturnID { get; set; }
        public long SaleID { get; set; }
        public DateTime ReturnDate { get; set; }
        public string? Reason { get; set; }
        public decimal TotalRefundAmount { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
