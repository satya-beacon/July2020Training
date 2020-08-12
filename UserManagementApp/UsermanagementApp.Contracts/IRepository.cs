using System;
using System.Collections.Generic;
using System.Text;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;

namespace UsermanagementApp.Contracts
{
    public interface IRepository
    {
        void CreateUserProfile(UserProfile userProfile);
        bool ValidateUser(LoginViewModel loginViewModel);
        UserProfile GetUserprofile(string username);
    }
}
