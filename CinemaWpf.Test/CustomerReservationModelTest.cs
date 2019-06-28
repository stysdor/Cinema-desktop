using System;
using CinemaWpf.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaWpf.Test
{
    [TestClass]
    public class CustomerReservationModelTest
    {
        private CustomerReservation customerReservation;

        [TestInitialize]
        public void SetUp()
        {
            customerReservation = new CustomerReservation();
        }

        [TestMethod]
        public void IsNotValidWhenCustomerAndReservationNull ()
        {
            Assert.AreEqual(customerReservation.IsValid, false);
        }

        [TestMethod]
        public void IsNotValidWhenCustomerInvalid()
        {
            customerReservation.Reservation = new Reservation()
            {
                ShowingId = 1,
                RowSeatId = 1
            };
            Assert.AreEqual(customerReservation.IsValid, false);
        }

        [TestMethod]
        public void IsNotValidWhenReservationInvalid()
        {
            customerReservation.Customer = new Customer()
            {
                CustomerName = "Steve",
                CustomerSurname = "Bridge"
            };
            Assert.AreEqual(customerReservation.IsValid, false);
        }

        [TestMethod]
        public void IsValidWhenReservationandCustomerAreValid()
        {
            customerReservation.Customer = new Customer()
            {
                CustomerName = "Steve",
                CustomerSurname = "Bridge"
            };
            customerReservation.Reservation = new Reservation()
            {
                ShowingId = 1,
                RowSeatId = 1
            };
            Assert.AreEqual(customerReservation.IsValid, true);
        }
    }
}
