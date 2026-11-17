namespace MyERP.Domain.DomainEntities
{
    public class ProductPriceDomain
    {
        public int ProductPriceID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
