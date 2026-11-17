namespace MyERP.Domain.DomainEntities
{
    public class InventoryDomain
    {
        public int InventoryID { get; set; }

        public int ProductID { get; set; }

        public int QuantityOnHand { get; set; }

        public int ReservedQuantity { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
