using eCommerceWeb.Contracts;
using eCommerceWeb.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceWeb.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IRepository repository;
        public UserBusiness(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task AddUser(User user)
        {
            await this.repository.AddUser(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await this.repository.GetUserById(id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await this.repository.GetUsers();
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            return await this.repository.ValidateUser(username, password);
        }
    }
}
