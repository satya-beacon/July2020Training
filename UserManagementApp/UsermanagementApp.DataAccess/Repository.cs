using System;
using System.Collections.Generic;
using System.Linq;
using UsermanagementApp.Contracts;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;

namespace UsermanagementApp.DataAccess
{
    public class Repository : IRepository
    {
        private UserDbContext context;

        public Repository()
        {
            this.context = new UserDbContext();
        }
        public void CreateUserProfile(UserProfile userProfile)
        {
            userProfile.CreateDt = DateTime.Now;
            userProfile.CreateBy = "System";
            this.context.Userprofiles.Add(userProfile);
            this.context.SaveChanges();
        }

        public List<UserProfile> GetAllUsers()
        {
            return this.context.Userprofiles.ToList();
        }

        public UserProfile GetUserprofile(string username)
        {
            return this.context.Userprofiles.FirstOrDefault(up => up.Username == username);
        }

        public UserProfile GetUserprofile(int id)
        {
            return this.context.Userprofiles.FirstOrDefault(up => up.Id == id);
        }

        public bool ValidateUser(LoginViewModel loginViewModel)
        {
            var user = this.context.Userprofiles.FirstOrDefault(up => up.Username == loginViewModel.Username && up.Password == loginViewModel.Password);
            return user != null ? true : false;
        }
    }
}
