using MyERP.Domain.Enums;

namespace MyERP.Infrastructure.Persistence.Entities
{
    public class Sale
    {
        public long SaleID { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;

        /// <summary>Nullable — POS supports walk-in sales with no customer selected.</summary>
        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }

        /// <summary>
        /// ApplicationUser.Id of the cashier. Plain string, not a
        /// navigation-backed FK — see ApplicationDbContext.
        /// </summary>
        public string? CashierUserID { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        public decimal SubTotal { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public SaleStatus Status { get; set; } = SaleStatus.Completed;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<SaleReturn> SaleReturns { get; set; } = new List<SaleReturn>();
    }

}
