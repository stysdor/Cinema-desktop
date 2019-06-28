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
    /// Represents ViewModel for MoviesView.
    /// </summary>
    public class MoviesViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// List of all movies.
        /// </summary>
        public ObservableCollection<Movie> Movies { get; set; }

        private Movie selectedMovie;
        /// <summary>
        /// Movie choosed by a user.
        /// </summary>
        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set { selectedMovie = value; NotifyPropertyChanged("SelectedMovie"); }
        }
        public MovieController Controller { get; set; }
        private ICommand editMovie;
        private ICommand removeMovie;
        private ICommand addMovie;

        /// <summary>
        /// Initialize a new instance of MoviesViewModel class.
        /// </summary>
        public MoviesViewModel()
        {
            Controller = new MovieController();
            Movies = Controller.GetMovies();
            EditMovie = new RelayCommand<object>(EditMovieExecute,EditMovieCanExecute);
            AddMovie = new RelayCommand<object>(AddMovieExecute,AddMovieCanExecute);
            RemoveMovie = new RelayCommand<object>(RemoveMovieExecute,RemoveMovieCanExecute);
        }

        #region AddMovie Members

        /// <summary>
        /// Command for adding movie.
        /// </summary>
        public ICommand AddMovie
        {
            get { return addMovie; }
            set
            {
                addMovie = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AddMovie)));
            }
        }

        private bool AddMovieCanExecute(object obj)
        {
            //Allow execute anytime
            return true;
        }

        private void AddMovieExecute(object obj)
        {
            MovieView view = new MovieView();
            view.Show();
        }
        #endregion

        #region EditMovie Members

        public ICommand EditMovie
        {
            get { return editMovie; }
            set
            {
                editMovie = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EditMovie)));
            }
        }

        private bool EditMovieCanExecute(object obj)
        {
            // Only allow execute if SelectedMovie exists
            return !(SelectedMovie == null);
        }

        private void EditMovieExecute(object obj)
        {
            MovieView view = new MovieView(SelectedMovie);
            view.Show();
        }
        #endregion

        #region RemoveMovie Members

        public ICommand RemoveMovie
        {
            get { return removeMovie; }
            set
            {
                removeMovie = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RemoveMovie)));
            }
        }

        private bool RemoveMovieCanExecute(object obj)
        {
            // Only allow execute if SelectedMovie exists
            return !(SelectedMovie == null);
        }

        private void RemoveMovieExecute(object obj)
        {
            Controller.Delete(SelectedMovie);
            Movies.Remove(SelectedMovie);
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
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
