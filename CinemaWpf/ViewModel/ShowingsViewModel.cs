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
    /// ViewModel for list of showings.
    /// </summary>
    public class ShowingsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Showing> Showings { get; set; }
        public ShowingController Controller { get; set; }

        /// <summary>
        /// Initialize a new instance of ReservationsViewModel class.
        /// </summary>
        public ShowingsViewModel()
        {
            Controller = new ShowingController();
            Showings = Controller.GetShowings();
            EditShowing = new RelayCommand<object>(EditShowingExecute, EditShowingCanExecute);
            AddShowing = new RelayCommand<object>(AddShowingExecute, AddShowingCanExecute);
            RemoveShowing = new RelayCommand<object>(RemoveShowingExecute, RemoveShowingCanExecute);
        }
        private Showing selectedShowing;
        /// <summary>
        /// Showing selected by user.
        /// </summary>
        public Showing SelectedShowing
        {
            get { return selectedShowing; }
            set { selectedShowing = value; NotifyPropertyChanged("SelectedShowing"); }
        }

        private ICommand editShowing;
        private ICommand removeShowing;
        private ICommand addShowing;

        #region AddShowing Members

        public ICommand AddShowing
        {
            get { return addShowing; }
            set
            {
                addShowing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AddShowing)));
            }
        }

        private bool AddShowingCanExecute(object obj)
        {
            //Allow execute anytime
            return true;
        }

        private void AddShowingExecute(object obj)
        {
            ChooseMovieView view = new ChooseMovieView();
            view.Show();
        }
        #endregion

        #region EditShowing Members

        public ICommand EditShowing
        {
            get { return editShowing; }
            set
            {
                editShowing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EditShowing)));
            }
        }

        private bool EditShowingCanExecute(object obj)
        {
            // Only allow execute if SelectedMovie exists
            return !(SelectedShowing == null);
        }

        private void EditShowingExecute(object obj)
        {
            ShowingView view = new ShowingView(SelectedShowing);
            view.Show();
        }
        #endregion

        #region RemoveShowing Members

        public ICommand RemoveShowing
        {
            get { return removeShowing; }
            set
            {
                removeShowing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RemoveShowing)));
            }
        }

        private bool RemoveShowingCanExecute(object obj)
        {
            // Only allow execute if SelectedMovie exists
            return !(SelectedShowing == null);
        }

        private void RemoveShowingExecute(object obj)
        {
            Controller.Delete(SelectedShowing);
            Showings.Remove(SelectedShowing);

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
