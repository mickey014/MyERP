using MyERP.Domain.Enums;

namespace MyERP.Domain.DomainEntities
{
    public class InventoryTransactionDomain
    {
        public long InventoryTransactionID { get; set; }

        public int ProductID { get; set; }

        public InventoryTransactionType TransactionType { get; private set; }

        public int Quantity { get; set; }

        public long? ReferenceID { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? Remarks { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? CreatedBy { get; set; }

        public void PurchaseType()
        {
            TransactionType = InventoryTransactionType.Purchase;
        }
        public void SaleType()
        {
            TransactionType = InventoryTransactionType.Sale;
        }
        public void ReturnType()
        {
            TransactionType = InventoryTransactionType.Return;
        }
        public void AdjustmentType()
        {
            TransactionType = InventoryTransactionType.Adjustment;
        }
        public void TransferType()
        {
            TransactionType = InventoryTransactionType.Transfer;
        }
    }

}
