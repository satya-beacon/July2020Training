﻿using System;
using System.Collections.Generic;
using UsermanagementApp.Contracts;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;

namespace UsermanagementApp.Business
{
    public class UserDomain : IUserDomain
    {
        private IRepository repository;
        private ILogger logger;
        public UserDomain(IRepository repository, ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public void CreateUserprofile(UserProfile userProfile)
        {
            try
            {
                this.repository.CreateUserProfile(userProfile);
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Exception in bussiness: {ex.Message}");
            }
            
            
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
