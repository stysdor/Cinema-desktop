using CinemaWpf.Commands;
using CinemaWpf.Controllers;
using CinemaWpf.Model;
using CinemaWpf.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CinemaWpf.ViewModel
{
    /// <summary>
    /// ViewModel for Movie form.
    /// </summary>
    public class MovieViewModel : INotifyPropertyChanged 
    {
        private Movie movie;
        private MovieInfoViewModel childViewModel;
        public MovieController Controller { get; set; }

        /// <summary>
        /// Initalize a new instance of MovieViewModel class
        /// </summary>
        public MovieViewModel() {
            movie = new Movie();
            childViewModel = new MovieInfoViewModel();
            SaveCommand = new SaveMovieCommand(this);
            Controller = new MovieController();
        }

        /// <summary>
        /// Initializes a new instance of the MovieViewModel class with existing movie.
        /// </summary>
        /// <param name="model">Movie to edit.</param>
        public MovieViewModel(Movie model)
        {
            movie = model;
            childViewModel = new MovieInfoViewModel();
            SaveCommand = new SaveMovieCommand(this);
            Controller = new MovieController();
        }

        /// <summary>
        /// Gets the Movie instance
        /// </summary>
        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged("MovieTitle"); }
        }

        /// <summary>
        /// Gets the SaveCommand for the ViewModel
        /// </summary>
        public ICommand SaveCommand {
            get;
            private set;
        }

        /// <summary>
        /// Saves changes to the movie instance
        /// </summary>
        public void saveMovie()
        {
            bool isSend = false;
            if (Movie.isValid)
            {
                isSend = Controller.Post(Movie); 
            }
            if (isSend)
            {
                MovieInfoView view = new MovieInfoView()
                {
                    DataContext = childViewModel
                };

                childViewModel.Info = "Film o tytule '" + Movie.MovieTitle + "' został zapisany w bazie danych.";
                MovieView.GetInstance().Close();
                view.ShowDialog();
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
