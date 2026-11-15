namespace MyERP.Infrastructure.Persistence.Entities
{
    public class Payment
    {
        public long PaymentID { get; set; }

        public long SaleID { get; set; }
        public Sale Sale { get; set; } = null!;

        public int PaymentMethodID { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;

        public decimal Amount { get; set; }

        /// <summary>GCash/card reference number, if applicable.</summary>
        public string? ReferenceNumber { get; set; }

        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
    }

}
