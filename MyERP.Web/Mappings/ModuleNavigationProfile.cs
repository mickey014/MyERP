using AutoMapper;
using MyERP.Application.DTOs.Response;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Mappings
{
    public class ModuleNavigationProfile : Profile
    {
        public ModuleNavigationProfile()
        {
            CreateMap<ModuleSidebarDto, ModuleSidebarViewModel>();
            CreateMap<ModuleNavItemDto, ModuleNavItemViewModel>();
        }
    }
}
