using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoWebApp.Models;

namespace DemoWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BlogRepository repository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.repository = new BlogRepository();
        }

        public IActionResult Index()
        {
            var blogs = this.repository.GetBlogs();
            ViewData["CurrentDate"] = $"Hello ASP.NET Core, started on : {DateTime.Now.ToShortDateString()}";
           
            return View(blogs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
