using System.Collections.Generic;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;

namespace UsermanagementApp.Contracts
{
    public interface IUserDomain
    {
        void CreateUserprofile(UserProfile userProfile);
        UserProfile GetUserprofile(string username);
        bool ValidateUser(LoginViewModel loginViewModel);
        List<UserProfile> GetAllUsers();
        UserProfile GetUserprofile(int id);
    }
}
