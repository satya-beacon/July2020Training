using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsermanagementApp.Entity;
using UsermanagementApp.Web.UI.Controllers;

namespace UsermanagemenApp.Web.Test
{
    [TestClass]
    public class SampleControllerUnitTest
    {
        [TestMethod]
        public void SampleController_IndexTest()
        {
            SampleController sampleController = new SampleController();
            var result =  sampleController.Index() as  ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void SampleController_GetUserContactsSuccess()
        {
            SampleController sampleController = new SampleController();
            var result = sampleController.GetUserContacts() as ViewResult;
            var contacts = result.ViewData.Model as List<UserContact>;

            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Count > 0);
            Assert.AreEqual("Satya", contacts.FirstOrDefault().FirstName);
        }
    }
}
