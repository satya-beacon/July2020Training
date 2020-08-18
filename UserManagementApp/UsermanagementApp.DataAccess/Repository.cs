using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private ILogger logger;

        public Repository(ILogger logger, IConfiguration configuration)
        {
            this.context = new UserDbContext(configuration);
            this.logger = logger;
        }

        public void AddContact(UserContact userContact)
        {
            this.context.UserContacts.Add(userContact);
            this.context.SaveChanges();
        }

        public void CreateUserProfile(UserProfile userProfile)
        {
            try
            {
                userProfile.CreateDt = DateTime.Now;
                userProfile.CreateBy = "System";
                this.context.Userprofiles.Add(userProfile);
                this.context.SaveChanges();
                this.logger.LogInfo("User is creted!");
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex.Message);
            }
            
          
        }

        public ContactViewModel GetAllContacts(ContactFilterViewModel filterViewModel)
        {
            var outputModel = new ContactViewModel();
            outputModel.PageIndex = filterViewModel.PageIndex;

            var allContacts = this.context.UserContacts.Include(uc => uc.UserProfile).Where(uc => uc.UserProfile.Username == filterViewModel.Username).ToList();

            if (filterViewModel != null && !string.IsNullOrEmpty(filterViewModel.SearchString))
            {
                allContacts = allContacts.Where(up => up.FirstName.Contains(filterViewModel.SearchString) || up.LastName.Contains(filterViewModel.SearchString)).ToList();
            }

            outputModel.TotalItems = allContacts.Count;

            if (filterViewModel != null && filterViewModel.PageIndex > 0 && filterViewModel.PageSize > 0)
            {
                outputModel.Items = allContacts.Skip((filterViewModel.PageIndex - 1) * filterViewModel.PageSize).Take(filterViewModel.PageSize).ToList();
            }

            return outputModel;
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
