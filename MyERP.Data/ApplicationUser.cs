using Microsoft.AspNetCore.Identity;

namespace MyERP.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
