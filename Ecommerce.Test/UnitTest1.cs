using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using Entities;

namespace Ecommerce.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CustomerBL custBL = new CustomerBL();
            int expected = 10;

            var customer = custBL.Get(10);

            Assert.AreEqual<int>(expected, customer.ID);
        }

        [TestMethod]
        public void TestGetCustomer_WithNoId()
        {
            CustomerBL custBL = new CustomerBL();

            var customer = custBL.Get(0);

            Assert.IsNull(customer);
        }
    }
}
