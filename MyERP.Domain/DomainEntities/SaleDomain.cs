using MyERP.Domain.Enums;

namespace MyERP.Domain.DomainEntities
{
    public class SaleDomain
    {
        public long SaleID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public int? CustomerID { get; set; }
        public string? CashierUserID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public SaleStatus Status { get; private set; }
        public DateTime CreatedAt { get; set; }
        public void Completed()
        {
            Status = SaleStatus.Completed;
        }
        public void Pending()
        {
            Status = SaleStatus.Pending;
        }
        public void Voided()
        {
            Status = SaleStatus.Voided;
        }
    }

}
