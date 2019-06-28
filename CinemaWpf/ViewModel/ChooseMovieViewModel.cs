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
    /// Represent ViewModel for ChooseMovieView.
    /// </summary>
    public class ChooseMovieViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// ObservableCollection which contains list of all movies.
        /// </summary>
        public ObservableCollection<Movie> Movies { get; set; }
        private MovieController Controller;

        private Movie selectedMovie;
        /// <summary>
        /// SelectedMovie stories a choosing movie.
        /// </summary>
        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
                NotifyPropertyChanged("SelectedValue");
                Showing.MovieId = SelectedMovie.Id;
                Showing.MovieTitle = SelectedMovie.MovieTitle;
            }
        }

        /// <summary>
        /// Represents Showing model.
        /// </summary>
        public Showing Showing { get; set; }

        /// <summary>
        /// Initializes a ne instance of ChooseMovieViewModel Class.
        /// </summary>
        public ChooseMovieViewModel()
        {
            Controller = new MovieController();
            Movies = Controller.GetMovies();
            Showing = new Showing();
            ContinueAddShowing = new RelayCommand<object>(ContinueAddShowingExecute, ContinueAddShowingCanExecute);
        }

        private ICommand continueAddShowing;

        #region ContinueAddShowing Members

        /// <summary>
        /// Command for continue adding showing.
        /// </summary>
        public ICommand ContinueAddShowing
        {
            get { return continueAddShowing; }
            set
            {
                continueAddShowing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ContinueAddShowing)));
            }
        }

        private bool ContinueAddShowingCanExecute(object obj)
        {
            //Allow execute if movie is choosed
            return (SelectedMovie == null) ? false : true;
        }

        private void ContinueAddShowingExecute(object obj)
        {
            ShowingView view = new ShowingView()
            {
                DataContext = new ShowingViewModel(Showing)
            };
            ChooseMovieView.GetInstance().Close();
            view.Show();
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
