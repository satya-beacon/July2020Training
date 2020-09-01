using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceWeb.Entity.ViewModels
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Username = user.Username;
            Token = token;
        }
    }
}
