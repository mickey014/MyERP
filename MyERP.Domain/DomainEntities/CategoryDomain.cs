namespace MyERP.Domain.DomainEntities
{
    public class CategoryDomain
    {
        public int CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; set; }
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
