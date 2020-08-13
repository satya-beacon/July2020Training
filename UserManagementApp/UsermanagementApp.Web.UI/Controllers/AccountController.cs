using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using System.Collections.Generic;
using System.Linq;
using UsermanagementApp.Business;
using UsermanagementApp.Contracts;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;

namespace UsermanagementApp.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private IUserDomain userDomain;

        public AccountController()
        {
            this.userDomain = new UserDomain();
        }
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var isValid = this.userDomain.ValidateUser(loginViewModel);
            if (isValid)
            {
                HttpContext.Session.SetString("userToken", loginViewModel.Username);
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewData["UnAuthorizedMessage"] = "Your credentails are Invalid, Please try again!";
                return View();
            }
           
        }

        public IActionResult Signup()
        {
            ViewData["Title"] = "Signup";
            return View();
        }

        [HttpPost]
        public IActionResult Signup(UserProfile userProfile)
        {
            this.userDomain.CreateUserprofile(userProfile);
            return RedirectToAction("Login");
        }

        public IActionResult Welcome()
        {
            ViewData["Title"] = "Welcome";
            var loggedUsername = HttpContext.Session.GetString("userToken");
            UserProfile userProfile = null;
            if (!string.IsNullOrEmpty(loggedUsername))
            {
                userProfile = this.userDomain.GetUserprofile(loggedUsername);
            }
            else
            {
                return BadRequest("Bad Request");
            }
            return View(userProfile);
        }

        public IActionResult ProfileView(int? id)
        {
            ViewData["Title"] = "My Profile";
            var loggedUsername = HttpContext.Session.GetString("userToken");
           
            UserProfile userProfile = null;
            
            if(id != null && id > 0)
            {
                userProfile = this.userDomain.GetUserprofile(id.Value);
            }
            else
            {
                if (!string.IsNullOrEmpty(loggedUsername))
                {
                    userProfile = this.userDomain.GetUserprofile(loggedUsername);
                }
                else
                {
                    return BadRequest("Bad Request");
                }
            }

            
            return View(userProfile);
        }

        public IActionResult Signout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult ViewAll(string searchString)
        {
            var allUsers = this.userDomain.GetAllUsers();
            if (!string.IsNullOrEmpty(searchString))
            {
                allUsers = allUsers.Where(up => up.LastName.Contains(searchString)).ToList();
            }
            return View(allUsers);
        }
    }
}
