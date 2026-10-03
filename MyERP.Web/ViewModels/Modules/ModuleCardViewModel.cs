namespace MyERP.Web.ViewModels.Modules
{
    public class ModuleCardViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
        public string? Badge { get; set; }
        public string ColorTheme { get; set;  } = string.Empty;
        public List<string> Features { get; set; } = new();

    }
}
