using MyERP.Domain.Enums;

namespace MyERP.Infrastructure.Persistence.Entities
{
    public class InventoryTransaction
    {
        public long InventoryTransactionID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; } = null!;

        public InventoryTransactionType TransactionType { get; set; }

        /// <summary>Signed: positive for stock in, negative for stock out.</summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Loose pointer to whatever caused this movement (e.g. a SaleID).
        /// Deliberately not a hard foreign key — the source can be a sale
        /// today and a purchase order or transfer once those modules
        /// exist, so this stays a plain nullable value, not a navigation.
        /// </summary>
        public long? ReferenceID { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? Remarks { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; }
    }

}
