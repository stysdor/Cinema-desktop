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
    /// ViewModel for Reservation list View.
    /// </summary>
    public class ReservationsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CustomerReservation> Reservations { get; set; }
        public ReservationController Controller { get; set; }

        /// <summary>
        /// Initialize a new instance of ReservationsViewModel class.
        /// </summary>
        public ReservationsViewModel()
        {
            Controller = new ReservationController();
            Reservations = Controller.GetReservations();
            Confirm = new RelayCommand<object>(EditReservationExecute, EditReservationCanExecute);
            AddReservation = new RelayCommand<object>(AddReservationExecute, AddReservationCanExecute);
            RemoveReservation = new RelayCommand<object>(RemoveReservationExecute, RemoveReservationCanExecute);
        }

        private CustomerReservation selectedReservation;
        public CustomerReservation SelectedReservation
        {
            get { return selectedReservation; }
            set { selectedReservation = value; NotifyPropertyChanged("SelectedReservation"); }
        }

        private ICommand confirm;
        private ICommand removeReservation;
        private ICommand addReservation;

        #region AddReservation Members

        public ICommand AddReservation
        {
            get { return addReservation; }
            set
            {
                addReservation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AddReservation)));
            }
        }

        private bool AddReservationCanExecute(object obj)
        {
            //Allow execute anytime
            return true;
        }

        private void AddReservationExecute(object obj)
        {
            ChooseShowingView view = new ChooseShowingView()
            {
                DataContext = new ChooseShowingViewModel()
            };
            view.Show();
        }
        #endregion

        #region EditReservation Members

        public ICommand Confirm
        {
            get { return confirm; }
            set
            {
                confirm = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Confirm)));
            }
        }

        private bool EditReservationCanExecute(object obj)
        {
            // Only allow execute if SelectedMovie exists
            return !(SelectedReservation == null);
        }

        private void EditReservationExecute(object obj)
        {
            Controller.Confirm(SelectedReservation);
        }
        #endregion

        #region RemoveReservation Members

        /// <summary>
        /// Command for removing reservation.
        /// </summary>
        public ICommand RemoveReservation
        {
            get { return removeReservation; }
            set
            {
                removeReservation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RemoveReservation)));
            }
        }

        private bool RemoveReservationCanExecute(object obj)
        {
            // Only allow execute if SelectedReservation exists
            return !(SelectedReservation == null);
        }

        private void RemoveReservationExecute(object obj)
        {
            Controller.Delete(SelectedReservation);
            Reservations.Remove(SelectedReservation);

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
