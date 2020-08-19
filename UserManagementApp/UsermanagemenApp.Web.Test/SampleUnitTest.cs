using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsermanagemenApp.Web.Test
{
    [TestClass]
    public class SampleUnitTest
    {
        [TestMethod]
        public void SampleTests_SayHelloSuccess()
        {
            SampleBL sampleBL = new SampleBL();
            var response = sampleBL.SayHello("satya");
            Assert.IsNotNull(response);
            Assert.IsTrue(response == "Hello.. satya");

        }

        [TestMethod]
        public void SampleTests_SayHelloNoInput()
        {
            SampleBL sampleBL = new SampleBL();
            var response = sampleBL.SayHello("");
            Assert.IsNull(response);

        }

        [TestMethod]
        public void SampleTests_SayHelloException()
        {
            SampleBL sampleBL = new SampleBL();
            try
            {
                var response = sampleBL.SayHello(null);
                Assert.IsNotNull(response);
            }
            catch(Exception ex)
            {
                Assert.IsNotNull(ex);
            }
            

        }
    }
}
