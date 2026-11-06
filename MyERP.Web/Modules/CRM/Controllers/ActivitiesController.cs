using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.CRM.Controllers
{
    [Route("/CRM/Activities")]
    public class ActivitiesController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel
            {
                PageTitle = "Activities",
                Icon = "fa-solid fa-calendar-check",
                Message = "Logged calls, emails, meetings, and site visits tied to customers, leads, and opportunities will be built with the Activities table."
            };

            return View(model);
        }
    }
}
