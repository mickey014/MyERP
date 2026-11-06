
using MyERP.Application.DTOs.Response;

namespace MyERP.Infrastructure.Configurations
{
    public static class CRMNavigation
    {
        public static ModuleSidebarDto GetSideBar()
        {
            return new ModuleSidebarDto
            {
                ModuleTitle = "CRM System",
                ModuleIcon = "fa-solid fa-users",
                Items =
                [
                    new() { Label = "Dashboard", Icon = "fa-solid fa-gauge-high", Url = "/CRM" },
                    new() { Label = "Customers", Icon = "fa-solid fa-address-book", Url = "/CRM/Customers" },
                    new() { Label = "Leads", Icon = "fa-solid fa-user-plus", Url = "/CRM/Leads" },
                    new() { Label = "Opportunities", Icon = "fa-solid fa-handshake", Url = "/CRM/Opportunities" },
                    new() { Label = "Activities", Icon = "fa-solid fa-calendar-check", Url = "/CRM/Activities" },
                    new() { Label = "Follow-ups", Icon = "fa-solid fa-bell", Url = "/CRM/FollowUps" }
                ]
            };
        }
    }
}
