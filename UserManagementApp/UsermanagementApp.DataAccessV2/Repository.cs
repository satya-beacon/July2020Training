using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsermanagementApp.Contracts;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;

namespace UsermanagementApp.DataAccessV2
{
    public class Repository : IRepository
    {
        private List<UserProfile> data;
        public Repository()
        {
            this.data = new List<UserProfile>();
        }


        public void CreateUserProfile(UserProfile userProfile)
        {
            if(this.data.Count > 0)
            {
                userProfile.Id = this.data.Count + 1; 
            }else
            {
                userProfile.Id = 1;
            }

            this.data.Add(userProfile);
        }

        public List<UserProfile> GetAllUsers()
        {
            return this.data;
        }

        public UserProfile GetUserprofile(string username)
        {
            return this.data.FirstOrDefault(up => up.Username == username);
        }

        public UserProfile GetUserprofile(int id)
        {
            return this.data.FirstOrDefault(up => up.Id == id);
        }

        public bool ValidateUser(LoginViewModel loginViewModel)
        {
            var userData = this.data.FirstOrDefault(up => up.Username == loginViewModel.Username && up.Password == loginViewModel.Password);
            return userData != null ? true : false;
        }
    }
}
