namespace MyERP.Infrastructure.Persistence.Entities
{
    public class ActivityType
    {
        public int ActivityTypeID { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}
