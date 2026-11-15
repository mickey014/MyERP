namespace MyERP.Infrastructure.Persistence.Entities
{
    public class PaymentMethod
    {
        public int PaymentMethodID { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
