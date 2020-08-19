using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsermanagementApp.Entity;

namespace UsermanagementApp.Web.UI.Controllers
{
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Greet()
        {
            return View(new {Name= "Satya", Address = "RI"});
        }

        public IActionResult GetUserContacts()
        {
            var contacts = new List<UserContact>()
            {
                new UserContact() { Id = 1, FirstName = "Satya", LastName = "Palakurla", Email ="satya@gmail.com" }
            };
            return View(contacts);
        }
    }
}
