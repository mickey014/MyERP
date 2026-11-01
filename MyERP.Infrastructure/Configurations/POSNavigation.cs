
using MyERP.Application.DTOs.Response;

namespace MyERP.Infrastructure.Configurations
{
    public static class POSNavigation
    {
        public static ModuleSidebarDto GetSideBar()
        {
            return new ModuleSidebarDto
            {
                ModuleTitle = "POS System",
                ModuleIcon = "fa-solid fa-cash-register",
                Items =
                [
                    new() { Label = "Dashboard", Icon = "fa-solid fa-gauge-high", Url = "/POS" },
                    new() { Label = "Terminal", Icon = "fa-solid fa-cash-register", Url = "/POS/Terminal" },
                    new() { Label = "Products", Icon = "fa-solid fa-box", Url = "/POS/Products" },
                    new() { Label = "Categories", Icon = "fa-solid fa-tags", Url = "/POS/Categories" },
                    new() { Label = "Sales", Icon = "fa-solid fa-receipt", Url = "/POS/Sales" },
                    new() { Label = "Payments", Icon = "fa-solid fa-credit-card", Url = "/POS/Payments" },
                    new() { Label = "Returns", Icon = "fa-solid fa-rotate-left", Url = "/POS/Returns" },
                    new() { Label = "Inventory", Icon = "fa-solid fa-warehouse", Url = "/POS/Inventory" }
                ]
            };
        }
    }
}
