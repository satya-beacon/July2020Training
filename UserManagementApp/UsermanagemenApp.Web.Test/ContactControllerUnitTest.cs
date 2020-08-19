using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UsermanagementApp.Web.UI.Controllers;
using Moq;
using UsermanagementApp.Contracts;
using UsermanagementApp.Entity;
using UsermanagementApp.Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UsermanagemenApp.Web.Test
{
    [TestClass]
    public class ContactControllerUnitTest
    {
        [TestMethod]
        public void ContactController_IndexSuccess()
        {
            var mockUserDomain = new Mock<IUserDomain>();
            mockUserDomain.Setup(p => p.GetAllUsers()).Returns(() => new List<UserProfile>() { new UserProfile() { Id = 1, FirstName = "Satya", LastName = "Palakurla", Email = "satya@gmail.com" } });
            mockUserDomain.Setup(p => p.ValidateUser(It.IsAny<LoginViewModel>())).Returns(() => true);


            var mockContatDomain = new Mock<IContactDomain>();
            mockContatDomain.Setup(p => p.GetAllContacts(It.IsAny<ContactFilterViewModel>())).Returns(() => new ContactViewModel() { PageIndex = 1, TotalItems = 10, Items = new List<UserContact>() { new UserContact() { Id = 1, FirstName = "satya", LastName = "palakurla", Email = "satya@gmail.com" } } });


            ContactController contactController = new ContactController(mockContatDomain.Object, mockUserDomain.Object);


            var result = contactController.Index() as ViewResult;
            Assert.IsNotNull(result);

            var userContactList = result.ViewData.Model as List<UserContact>;
            Assert.IsNotNull(userContactList);

            
            Assert.AreEqual(1, userContactList.Count);

            Assert.AreEqual("satya@gmail.com", userContactList.FirstOrDefault().Email);


        }
    }
}
