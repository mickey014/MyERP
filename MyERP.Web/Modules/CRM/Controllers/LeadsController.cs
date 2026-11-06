using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.CRM.Controllers
{
    [Route("/CRM/Leads")]
    public class LeadsController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel
            {
                PageTitle = "Leads",
                Icon = "fa-solid fa-user-plus",
                Message = "Lead capture and the New → Contacted → Qualified → Converted pipeline will be built with the Leads, LeadSources, and LeadStatuses tables."
            };

            return View(model);
        }
    }
}
