namespace MyERP.Web.Modules.Module.ViewModels
{
    public class ModuleDashboardPageViewModel
    {
        public string PageTitle { get; set; } = string.Empty;
        public string PageSubtitle { get; set; } = string.Empty;
        public List<DashboardStatViewModel> Stats { get; set; } = new();
    }
}
