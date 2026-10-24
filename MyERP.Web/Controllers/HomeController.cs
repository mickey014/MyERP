using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MyERP.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Modules");
        }
    }
}
