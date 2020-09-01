using eCommerceWeb.Entity;
using eCommerceWeb.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceWeb.Contracts;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace eCommerceWeb.API.Helpers
{
    public class UserService : IUserService
    {
        private readonly IUserBusiness userBusiness;
        private readonly IOptions<AppSettings> _appSettings;

        public UserService(IUserBusiness userBusiness, IOptions<AppSettings> options)
        {
            this.userBusiness = userBusiness;
            _appSettings = options;
        }
        
       public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticateRequest)
        {
            var user = await userBusiness.ValidateUser(authenticateRequest.Username, authenticateRequest.Password);
            if(user == null)
            {
                return null;
            }

            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);

        }


        // helper methods

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim("username", user.Username) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
