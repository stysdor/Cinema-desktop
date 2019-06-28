using System;
using CinemaWpf.Model;
using CinemaWpf.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaWpf.Test
{
    [TestClass]
    public class MoviesViewModelTest
    {

        [TestMethod]
        public void CanAlwaysExecuteAddMovieCommand()
        {
            MoviesViewModel model = new MoviesViewModel();
            Assert.IsTrue(model.AddMovie.CanExecute(null));
        }

        [TestMethod]
        public void CantExecuteEditMovieCommandWhenNothingSelected()
        {
            MoviesViewModel model = new MoviesViewModel();
            Assert.IsFalse(model.EditMovie.CanExecute(null));
        }

        [TestMethod]
        public void CantExecuteRemovieMovieCommandWhenNothingSelected()
        {
            MoviesViewModel model = new MoviesViewModel();
            Assert.IsFalse(model.RemoveMovie.CanExecute(null));
        }

        [TestMethod]
        public void CanExecuteEditMovieCommandWhenMovieSelected()
        {
            MoviesViewModel model = new MoviesViewModel();
            model.SelectedMovie = new Movie();
            Assert.IsTrue(model.EditMovie.CanExecute(null));
        }

        [TestMethod]
        public void CanExecuteRemovieMovieCommandWhenMovieSelected()
        {
            MoviesViewModel model = new MoviesViewModel();
            model.SelectedMovie = new Movie();
            Assert.IsTrue(model.RemoveMovie.CanExecute(null));
        }
    }
}
