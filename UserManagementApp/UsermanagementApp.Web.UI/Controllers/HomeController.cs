﻿using Microsoft.AspNetCore.Mvc;

namespace UsermanagementApp.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
