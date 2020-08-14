using System;
using System.Collections.Generic;
using System.Text;
using UsermanagementApp.Contracts;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;

namespace UsermanagementApp.BussinessV2
{
    public class UserDomain : IUserDomain
    {
        private IRepository repository;

        public UserDomain(IRepository repository)
        {
            this.repository = repository;
        }
        public void CreateUserprofile(UserProfile userProfile)
        {
            this.repository.CreateUserProfile(userProfile);
        }

        public List<UserProfile> GetAllUsers()
        {
            return this.repository.GetAllUsers();
        }

        public UserProfile GetUserprofile(string username)
        {
            return this.repository.GetUserprofile(username);
        }

        public UserProfile GetUserprofile(int id)
        {
            return this.repository.GetUserprofile(id);
        }

        public bool ValidateUser(LoginViewModel loginViewModel)
        {
            return this.repository.ValidateUser(loginViewModel);
        }
    }
}
