namespace MyERP.Domain.DomainEntities
{
    public class PaymentMethodDomain
    {
        public int PaymentMethodID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public void Deactivate()
        {
            IsActive = false;
        }
        public void Activate()
        {
            IsActive = true;
        }

    }
}
