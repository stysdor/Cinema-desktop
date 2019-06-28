using System;
using System.ComponentModel;
using CinemaWpf.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CinemaWpf.Test
{
    [TestClass]
    public class CustomerModelTest
    {
        private Customer customer;

        [TestInitialize]
        public void SetUp()
        {
            customer = new Customer();
        }

        [TestMethod]
        public void IsDataErrorInfo()
        {
            Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(Customer)));
        }

        [TestMethod]
        public void ValidateNullName()
        {
            Assert.IsNotNull(customer["CustomerName"]);
        }
         
        [TestMethod]
        public void ValidateInvalidName()
        {
            customer.CustomerName = "jo";
            Assert.IsNotNull(customer["CustomerName"]);
        }

        [TestMethod]
        public void ValidateProperName()
        {
            customer.CustomerName = "Dorota";
            Assert.IsNull(customer["CustomerName"]);
        }

        [TestMethod]
        public void ValidateNullSurname()
        {
            Assert.IsNotNull(customer["CustomerSurname"]);
        }

        [TestMethod]
        public void ValidateInvalidSurname()
        {
            customer.CustomerSurname = "jo";
            Assert.IsNotNull(customer["CustomerSurname"]);
        }

        [TestMethod]
        public void ValidateProperSurname()
        {
            customer.CustomerSurname = "Dorota";
            Assert.IsNull(customer["CustomerSurname"]);
        }

        [TestMethod]
        public void ValidateNullPhone()
        {
            Assert.IsNull(customer["Phone"]);
        }

        [TestMethod]
        public void ValidateInvalidPhone()
        {
            customer.Phone = "jo";
            Assert.IsNotNull(customer["Phone"]);
        }

        [TestMethod]
        public void ValidateProperPhone()
        {
            customer.Phone = "123456789";
            Assert.IsNull(customer["Phone"]);
        }

        [TestMethod]
        public void ValidateNullEmail()
        {
            Assert.IsNull(customer["Email"]);
        }

        [TestMethod]
        public void ValidateInvalidEmail()
        {
            customer.Email = "jo";
            Assert.IsNotNull(customer["Email"]);
        }

        [TestMethod]
        public void ValidateProperEmail()
        {
            customer.Email = "bab@o2.pl";
            Assert.IsNull(customer["Email"]);
        }

    }
}
