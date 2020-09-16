using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eCommerceWeb.Contracts;
using eCommerceWeb.Entity;
using eCommerceWeb.Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using eCommerceWeb.API.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace eCommerceWeb.API.Controllers
{
    [Route("api/eCommerceWeb")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness userBusiness;
        private readonly IUserService userService;


        public UsersController(IUserBusiness userBusiness, IUserService userService)
        {
            this.userBusiness = userBusiness;
            this.userService = userService;
        }

        /// <summary>
        /// This is to add a new User
        /// </summary>
        /// <param name="user">Pass user object</param>
        /// <returns>Returns true/false</returns>
        [HttpPost]
        [Route("users")]
        public async Task<ActionResult<bool>> CreateUser([Required] [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid");
            }

            await this.userBusiness.AddUser(user);

            return Ok(true);
        }

        /// <summary>
        /// This is to validate the user and render the token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("authenticate")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = await userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("users")]
        [Helpers.Authorize] //This is custom authorize attribute
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var response = await this.userBusiness.GetUsers();
            return Ok(response);
        }


        /// <summary>
        /// Get User By name
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{username}")]
        [Helpers.Authorize] //This is custom authorize attribute
        public async Task<ActionResult<User>> GetUserByName(string username)
        {
            var response = await this.userBusiness.GetUserByName(username);
            return Ok(response);
        }
    }
}
