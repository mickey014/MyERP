namespace MyERP.Infrastructure.Persistence.Entities
{
    public class Product
    {
        public int ProductID { get; set; }

        public string SKU { get; set; } = string.Empty;

        /// <summary>Optional — not every product is barcoded.</summary>
        public string? Barcode { get; set; }

        public string Name { get; set; } = string.Empty;

        public int CategoryID { get; set; }
        public Category Category { get; set; } = null!;

        public string? Description { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public int ReorderLevel { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<ProductPrice> PriceHistory { get; set; } = new List<ProductPrice>();
        public ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
        public ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
        public Inventory? Inventory { get; set; }
    }
}
