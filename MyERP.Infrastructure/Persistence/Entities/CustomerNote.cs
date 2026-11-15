namespace MyERP.Infrastructure.Persistence.Entities
{
    public class CustomerNote
    {
        public int CustomerNoteID { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; } = null!;

        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// ApplicationUser.Id of the author. Stored as a plain string
        /// rather than a navigation-backed foreign key — see the
        /// "Identity references" note in ApplicationDbContext.
        /// </summary>
        public string? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
