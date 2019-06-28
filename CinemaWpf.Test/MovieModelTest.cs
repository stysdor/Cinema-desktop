using System;
using System.ComponentModel;
using CinemaWpf.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaWpf.Test
{
    [TestClass]
    public class MovieModelTest
    {
        private Movie movie;

        [TestInitialize]
        public void SetUp()
        {
            movie = new Movie();
        }

        [TestMethod]
        public void IsDataErrorInfo()
        {
            Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(Movie)));
        }

        [TestMethod]
        public void ValidateNullMovieTitle()
        {
            Assert.IsNotNull(movie["MovieTitle"]);
        }

        [TestMethod]
        public void ValidateInvalidMovieTitle()
        {
            movie.MovieTitle = "sd";
            Assert.IsNotNull(movie["MovieTitle"]);
        }

        [TestMethod]
        public void ValidateMovieTitle()
        {
            movie.MovieTitle = "Zielona mila";
            Assert.IsNull(movie["MovieTitle"]);
        }

        [TestMethod]
        public void ValidateNullMovieDescription()
        {
            Assert.IsNotNull(movie["MovieDescription"]);
        }

        [TestMethod]
        public void ValidateInvalidMovieDescription()
        {
            movie.MovieDescription = "Th";
            Assert.IsNotNull(movie["MovieDescription"]);
        }

        [TestMethod]
        public void ValidateMovieDescription()
        {
            movie.MovieDescription ="This is correct description.";
            Assert.IsNull(movie["MovieDescription"]);
        }

        [TestMethod]
        public void ValidateNullYearOfProduction()
        {
            Assert.IsNotNull(movie["YearOfProduction"]);
        }

        [TestMethod]
        public void ValidateInvalidYearOfProduction()
        {
            movie.YearOfProduction = "Thad";
            Assert.IsNotNull(movie["YearOfProduction"]);
            movie.YearOfProduction = "19996";
            Assert.IsNotNull(movie["YearOfProduction"]);
        }

        [TestMethod]
        public void ValidateYearOfProduction()
        {
            movie.YearOfProduction = "1991";
            Assert.IsNull(movie["YearOfProduction"]);
        }
    }
}
