using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using UsermanagementApp.Contracts;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;

namespace UsermanagementApp.Web.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserDomain userDomain;
        private ILogger logger;

        public string LoggedUser
        {
            get
            {
                return User?.Identity?.Name;
            }
        }

        public AccountController(IUserDomain userDomain, ILogger logger)
        {
            this.userDomain = userDomain;
            this.logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {

            if (!ModelState.IsValid)
            {
                ViewData["UnAuthorizedMessage"] = "Please enter credentails and try again!";
                this.logger.LogWarning("You didn't enter credentials");
                return View();
            }

            var isValid = this.userDomain.ValidateUser(loginViewModel);
            if (isValid)
            {
                this.logger.LogInfo("You logged!");
               
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, loginViewModel.Username),                    
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                if(loginViewModel.Username == "admin")
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                }
                else
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
                }
               
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Welcome");
            }
            else
            {
                ViewData["UnAuthorizedMessage"] = "Your credentails are Invalid, Please try again!";
                return View();
            }
           
        }
        
        [AllowAnonymous]
        public IActionResult Signup()
        {
            ViewData["Title"] = "Signup";
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Signup(UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Please fill all the required fields!";
                return View();
            }
            this.userDomain.CreateUserprofile(userProfile);
            return RedirectToAction("Login");
        }

        public IActionResult Welcome()
        {
            ViewData["Title"] = "Welcome";
            UserProfile userProfile = null;
            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                userProfile = this.userDomain.GetUserprofile(LoggedUser);
            }
            else
            {
                return BadRequest("Bad Request");
            }
            return View(userProfile);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult ProfileView(int? id)
        {
            ViewData["Title"] = "My Profile";
          
            UserProfile userProfile = null;
            
            if(id != null && id > 0)
            {
                userProfile = this.userDomain.GetUserprofile(id.Value);
            }
            else
            {
                if (!string.IsNullOrEmpty(LoggedUser))
                {
                    userProfile = this.userDomain.GetUserprofile(LoggedUser);
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
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

       [Authorize(Roles = "Admin")]
        public IActionResult ViewAll(string searchString)
        {
            var allUsers = this.userDomain.GetAllUsers();
            if (!string.IsNullOrEmpty(searchString))
            {
                allUsers = allUsers.Where(up => up.LastName.Contains(searchString)).ToList();
            }
            return View(allUsers);
        }


        public IActionResult EditProfile(int? id)
        {
            ViewData["Title"] = "Edit Profile";

            UserProfile userProfile = null;

            if (id != null && id > 0)
            {
                userProfile = this.userDomain.GetUserprofile(id.Value);
            }

            return View(userProfile);
        }
        
        [HttpPost]
        public IActionResult EditProfile(UserProfile viewmodel)
        {
            ViewData["Title"] = "Edit Profile";
           //logic to save

            return View(viewmodel);
        }
    }
}
