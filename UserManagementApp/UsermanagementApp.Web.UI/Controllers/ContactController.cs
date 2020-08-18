using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UsermanagementApp.Contracts;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;

namespace UsermanagementApp.Web.UI.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private IContactDomain contactDomain;
        private IUserDomain userDomain;
        public ContactController(IContactDomain contactDomain, IUserDomain userDomain)
        {
            this.contactDomain = contactDomain;
            this.userDomain = userDomain;
        }
        public IActionResult Index(int pageIndex =0)
        {
            
            var filterViewModel = new ContactFilterViewModel()
            {
                Username = User.Identity.Name,
                PageIndex = pageIndex > 0 ? pageIndex : 1,
                PageSize = 2
            };

            ViewData["pageIndex"] = filterViewModel.PageIndex;
            
            var contctViewModel = this.contactDomain.GetAllContacts(filterViewModel);
            ViewData["totalItems"] = contctViewModel.TotalItems;
            return View(contctViewModel.Items);
        }

        public IActionResult Create()
        {
            ViewData["StatesData"] = new List<SelectListItem>
                    {
                        new SelectListItem("Rhode Island", "RI"),
                        new SelectListItem("New Jersey", "NJ"),
                        new SelectListItem("New York", "NY")
                    };
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserContact userContact)
        {
            if (!ModelState.IsValid)
            {
                ViewData["BadRequest"] = "Model is not valid. Please fill all the requried fields!";
                return View();
            }
            var userProfile = this.userDomain.GetUserprofile(User.Identity.Name);
            userContact.UserId = userProfile.Id;
            this.contactDomain.AddContact(userContact);
            return RedirectToAction("Index");

        }
    }
}
