namespace MyERP.Application.DTOs.Response
{
    public class ModuleSidebarDto
    {
        public string ModuleTitle { get; set; } = string.Empty;
        public string ModuleIcon { get; set; } = string.Empty;
        public List<ModuleNavItemDto> Items { get; set; } = [];
    }
}
