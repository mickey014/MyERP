using MyERP.Domain.Modules;

namespace BusinessERP.Data.Configuration;

public static class ModuleRegistry
{
    public static List<Module> GetModules()
    {
        return
        [
            new()
            {
                Title = "POS System",
                Description = "Manage point-of-sale transactions, products, payments, sales, customers, and inventory.",
                Icon = "fa-solid fa-cash-register",
                Url = "/POS",
                ButtonText = "Open POS",
                IsEnabled = true,
                ColorTheme = "primary",
                Features =
                [
                    "POS Terminal",
                    "Products",
                    "Sales",
                    "Payments",
                    "Inventory"
                ]
            },

            new()
            {
                Title = "CRM System",
                Description = "Manage customers, leads, opportunities, activities, follow-ups, and customer relationships.",
                Icon = "fa-solid fa-users",
                Url = "/CRM",
                ButtonText = "Open CRM",
                IsEnabled = true,
                ColorTheme = "success",
                Features =
                [
                    "Customers",
                    "Leads",
                    "Opportunities",
                    "Activities",
                    "Follow-ups"
                ]
            },

            new()
            {
                Title = "Inventory",
                Description = "Manage stock levels, warehouses, transfers, and inventory adjustments across branches.",
                Icon = "fa-solid fa-boxes-stacked",
                Url = "/Inventory",
                ButtonText = "Open Inventory",
                IsEnabled = false,
                Badge = "Coming Soon",
                ColorTheme = "secondary"
            },

            new()
            {
                Title = "Purchasing",
                Description = "Manage purchase orders, suppliers, and procurement workflows.",
                Icon = "fa-solid fa-cart-arrow-down",
                Url = "/Purchasing",
                ButtonText = "Open Purchasing",
                IsEnabled = false,
                Badge = "Coming Soon",
                ColorTheme = "secondary"
            },

            new()
            {
                Title = "Accounting",
                Description = "Manage ledgers, invoices, expenses, and financial reporting.",
                Icon = "fa-solid fa-file-invoice-dollar",
                Url = "/Accounting",
                ButtonText = "Open Accounting",
                IsEnabled = false,
                ColorTheme = "secondary"
            },

            new()
            {
                Title = "HR & Payroll",
                Description = "Manage employees, attendance, payroll, and benefits.",
                Icon = "fa-solid fa-id-badge",
                Url = "/HR",
                ButtonText = "Open HR",
                IsEnabled = false,
                Badge = "Coming Soon",
                ColorTheme = "secondary"
            }
        ];
    }
}