using System;
using System.Collections.Generic;
using System.Text;

namespace MyERP.Infrastructure.Persistence.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
