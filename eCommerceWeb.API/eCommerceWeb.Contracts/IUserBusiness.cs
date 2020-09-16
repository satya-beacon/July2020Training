using eCommerceWeb.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceWeb.Contracts
{
    public interface IUserBusiness
    {
        Task AddUser(User user);
        Task<User> ValidateUser(string username, string password);
        Task<List<User>> GetUsers();

        Task<User> GetUserById(int id);
        
        Task<User> GetUserByName(string username);
    }
}
