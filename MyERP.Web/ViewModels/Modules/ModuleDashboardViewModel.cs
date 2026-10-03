namespace MyERP.Web.ViewModels.Modules
{
    public class ModuleDashboardViewModel
    {
        public string ApplicationName { get; set; } = "Business ERP";

        public string WelcomeMessage { get; set; } = "Welcome back";

        public string UserDisplayName { get; set; } = string.Empty;

        public List<ModuleCardViewModel> Modules { get; set; } = new();
    }
}
