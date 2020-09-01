using eCommerceWeb.Entity;
using eCommerceWeb.Entity.ViewModels;
using System.Threading.Tasks;

namespace eCommerceWeb.API.Helpers
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest authenticateRequest);
    }
}
