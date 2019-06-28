using System;
using System.ComponentModel;
using CinemaWpf.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaWpf.Test
{
    [TestClass]
    public class ReservationModelTest
    {
        private Reservation reservation;

        [TestInitialize]
        public void SetUp()
        {
            reservation = new Reservation();
        }

        [TestMethod]
        public void IsDataErrorInfo()
        {
            Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(Reservation)));
        }

        [TestMethod]
        public void ValidateNullShowingId()
        {
            Assert.IsNotNull(reservation["ShowingId"]);
        }

        [TestMethod]
        public void ValidateShowingId()
        {
            reservation.ShowingId = 2;
            Assert.IsNull(reservation["ShowingId"]);
        }

        [TestMethod]
        public void ValidateNullRowSeatId()
        {
            Assert.IsNotNull(reservation["RowSeatId"]);
        }

        [TestMethod]
        public void ValidateRowSeatId()
        {
            reservation.RowSeatId = 2;
            Assert.IsNull(reservation["RowSeatId"]);
        }
    }
}
