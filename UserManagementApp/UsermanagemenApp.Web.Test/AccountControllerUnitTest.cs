using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UsermanagementApp.Contracts;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;
using UsermanagementApp.Web.UI.Controllers;

namespace UsermanagemenApp.Web.Test
{
    [TestClass]
    public class AccountControllerUnitTest
    {
        [TestMethod]
        public void ProfileViewSuccess()
        {
            var mockUserDomain = new Mock<IUserDomain>();
            mockUserDomain.Setup(p => p.GetAllUsers()).Returns(() => new List<UserProfile>() { new UserProfile() { Id = 1, FirstName = "Satya", LastName = "Palakurla", Email = "satya@gmail.com" } });
            mockUserDomain.Setup(p => p.ValidateUser(It.IsAny<LoginViewModel>())).Returns(() => true);
            mockUserDomain.Setup(p => p.GetUserprofile(It.IsAny<int>())).Returns(() => new UserProfile() { Id = 1, FirstName = "satya", LastName = "palakurla"});


            var mockLoggerDomain = new Mock<ILogger>();


            AccountController accountController = new AccountController(mockUserDomain.Object, mockLoggerDomain.Object);

            var result = accountController.ProfileView(1) as ViewResult;
            Assert.IsNotNull(result);

            var userProfile = result.ViewData.Model as UserProfile;
            Assert.IsNotNull(userProfile);
            Assert.AreEqual("satya", userProfile.FirstName);

        }


        [TestMethod]
        public void ProfileViewFail()
        {
            var mockUserDomain = new Mock<IUserDomain>();
            mockUserDomain.Setup(p => p.GetAllUsers()).Returns(() => new List<UserProfile>() { new UserProfile() { Id = 1, FirstName = "Satya", LastName = "Palakurla", Email = "satya@gmail.com" } });
            mockUserDomain.Setup(p => p.ValidateUser(It.IsAny<LoginViewModel>())).Returns(() => true);
            mockUserDomain.Setup(p => p.GetUserprofile(It.IsAny<int>())).Returns(() => new UserProfile() { Id = 1, FirstName = "satya", LastName = "palakurla" });


            var mockLoggerDomain = new Mock<ILogger>();


            AccountController accountController = new AccountController(mockUserDomain.Object, mockLoggerDomain.Object);

            var result = accountController.ProfileView(null) as ViewResult;
            Assert.IsNull(result);
        }
    }
}
