namespace MyERP.Domain.DomainEntities
{
    public class PaymentDomain
    {
        public long PaymentID { get; set; }
        public long SaleID { get; set; }
        public int PaymentMethodID { get; set; }
        public decimal Amount { get; set; }
        public string? ReferenceNumber { get; set; }
        public DateTime PaidAt { get; set; }
    }

}
