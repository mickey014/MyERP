using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.CRM.Controllers
{
    [Route("/CRM/FollowUps")]
    public class FollowUpsController : Controller
    {
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel
            {
                PageTitle = "Follow-ups",
                Icon = "fa-solid fa-bell",
                Message = "Scheduled follow-up reminders and their completion status will be built with the FollowUps table."
            };

            return View(model);
        }
    }
}
