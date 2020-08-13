using Microsoft.AspNetCore.Mvc;

namespace UsermanagementApp.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }
    }
}
