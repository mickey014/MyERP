namespace MyERP.Infrastructure.Persistence.Entities
{
    /// <summary>
    /// A price-history row for a product, so selling-price changes over
    /// time are preserved even though Product.SellingPrice holds the
    /// current price for day-to-day use.
    /// </summary>
    public class ProductPrice
    {
        public int ProductPriceID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; } = null!;

        public decimal Price { get; set; }

        public DateTime EffectiveDate { get; set; } = DateTime.UtcNow;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
