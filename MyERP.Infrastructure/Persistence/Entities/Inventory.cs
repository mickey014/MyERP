namespace MyERP.Infrastructure.Persistence.Entities
{
    public class Inventory
    {
        public int InventoryID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; } = null!;

        public int QuantityOnHand { get; set; }

        public int ReservedQuantity { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
