using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Controllers
{
    [Controller]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
