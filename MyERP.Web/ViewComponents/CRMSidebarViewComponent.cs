using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MyERP.Infrastructure.Configurations;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.ViewComponents
{
    public class CRMSidebarViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;

        public CRMSidebarViewComponent(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            // Get navigation configuration from Infrastructure
            var sidebarDto = CRMNavigation.GetSideBar();

            // Convert Application DTO to Web ViewModel
            var sidebarViewModel =
                _mapper.Map<ModuleSidebarViewModel>(sidebarDto);

            // Return the converted ViewModel
            return new ViewViewComponentResult
            {
                ViewData = new ViewDataDictionary<ModuleSidebarViewModel>(
                    ViewData,
                    sidebarViewModel
                )
            };
        }
    }
}
