using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UsermanagementApp.Business;
using Moq;
using UsermanagementApp.Contracts;
using UsermanagementApp.Entity.ViewModels;
using System.Linq;

namespace UsermanagemenApp.Web.Test
{
    [TestClass]
    public class ContactDomainUnitTest
    {
        [TestMethod]
        public void GetContacts_UnitTestSuccess()
        {
            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetAllContacts(It.IsAny<ContactFilterViewModel>())).Returns(() => new ContactViewModel() { PageIndex = 1, TotalItems = 10 , Items = new List<UsermanagementApp.Entity.UserContact>() { new UsermanagementApp.Entity.UserContact() { Id =1 , FirstName = "satya", LastName ="pala"} } });

            ContactDomain contactDomain = new ContactDomain(mockRepository.Object);

            var response = contactDomain.GetAllContacts(null);
            Assert.IsNotNull(response);

            Assert.AreEqual(1, response.PageIndex);
            Assert.AreEqual(10, response.TotalItems);
            Assert.IsNotNull(response.Items);
            Assert.AreEqual("satya", response.Items.FirstOrDefault().FirstName);
        }
    }
}
