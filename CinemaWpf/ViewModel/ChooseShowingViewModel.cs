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
    /// Model of data for ChooseShowingView.
    /// </summary>
    public class ChooseShowingViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Showing> Showings { get; set; }
        private ShowingController Controller;
        private Showing selectedShowing;
        /// <summary>
        /// Selected Showing.
        /// </summary>
        public Showing SelectedShowing
        {
            get { return selectedShowing; }
            set {
                selectedShowing = value;
                NotifyPropertyChanged("SelectedValue");
                Reservation.Reservation.ShowingId = SelectedShowing.Id;
            }
        }

        /// <summary>
        /// Reservation object.
        /// </summary>
        public CustomerReservation Reservation;

        /// <summary>
        /// Initializes an instance of ChooseShowingModel class.
        /// </summary>
        public ChooseShowingViewModel()
        {
            Controller = new ShowingController();
            Showings = Controller.GetActuall(14);
            Reservation = new CustomerReservation();
            //AddReservation = new RelayCommand<object>(AddReservationExecute, AddReservationCanExecute);
            ContinueReservation = new RelayCommand<object>(ContinueReservationExecute, ContinueReservationCanExecute);
        }

        private ICommand continueReservation;

        #region ContinueReservation Members

        /// <summary>
        /// Command to go to the next step of reservation.
        /// </summary>
        public ICommand ContinueReservation
        {
            get { return continueReservation; }
            set
            {
                continueReservation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ContinueReservation)));
            }
        }

        private bool ContinueReservationCanExecute(object obj)
        {
            //Allow execute if showing is choosed
            return (SelectedShowing == null) ? false : true;
        }

        private void ContinueReservationExecute(object obj)
        {
            ReservationView view = new ReservationView()
            {
                DataContext = new ReservationViewModel(Reservation)
            };

            if (ChooseShowingView.GetInstance() != null)
            {
                ChooseShowingView.GetInstance().Close();
            }
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
 