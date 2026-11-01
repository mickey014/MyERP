namespace MyERP.Web.Modules.Module.ViewModels;

public class ModuleSidebarViewModel
{
    public string ModuleTitle { get; set; } = string.Empty;
    public string ModuleIcon { get; set; } = string.Empty;
    public List<ModuleNavItemViewModel> Items { get; set; } = new();
}
