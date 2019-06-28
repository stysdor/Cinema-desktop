using CinemaWpf.Commands;
using CinemaWpf.Controllers;
using CinemaWpf.Model;
using CinemaWpf.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CinemaWpf.ViewModel
{
    /// <summary>
    /// ViewModel for showing form.
    /// </summary>
    public class ShowingViewModel :INotifyPropertyChanged
    {
        private Showing showing;
        public ShowingController Controller;
        public string Now { get; set; }

        /// <summary>
        /// Initalize a new instance of ShowingViewModel class
        /// </summary>
        public ShowingViewModel()
        {
            Showing = new Showing();
            Showing.TheatreId = 1;
            SaveCommand = new SaveShowingCommand(this);
            Controller = new ShowingController();
            Now = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
        }

        /// <summary>
        /// Initializes a new instance of the ReservationViewModel class with existing movie.
        /// </summary>
        /// <param name="model">Reservation to edit.</param>
        public ShowingViewModel(Showing model)
        {
            Showing = model;
            Showing.TheatreId = 1;
            SaveCommand = new SaveShowingCommand(this);
            Controller = new ShowingController();
            Now = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
        }

        /// <summary>
        /// Gets the Reservation instance
        /// </summary>
        public Showing Showing
        {
            get { return showing; }
            set { showing = value; OnPropertyChanged("Showing"); }
        }

        /// <summary>
        /// Gets the SaveCommand for the ViewModel
        /// </summary>
        public ICommand SaveCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Saves changes to the showing instance
        /// </summary>
        public void saveShowing()
        {
            Controller.Post(Showing);
            ShowingView.GetInstance().Close();
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
