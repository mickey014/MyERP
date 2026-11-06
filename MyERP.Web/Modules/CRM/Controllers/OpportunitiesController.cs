using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.CRM.Controllers
{
    [Route("/CRM/Opportunities")]
    public class OpportunitiesController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel
            {
                PageTitle = "Opportunities",
                Icon = "fa-solid fa-handshake",
                Message = "The visual sales pipeline (New → Qualified → Proposal → Negotiation → Won) will be built with the Opportunities and OpportunityStages tables."
            };

            return View(model);
        }
    }
}
