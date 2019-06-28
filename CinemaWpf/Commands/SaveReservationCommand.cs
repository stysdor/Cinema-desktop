using CinemaWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CinemaWpf.Commands
{
    internal class SaveReservationCommand : ICommand
    {
        private ReservationViewModel viewModel;

        /// <summary>
        /// Initialize a new instance of the AddMovieCommandn class.
        /// </summary>
        /// <param name="viewModel"></param>
        public SaveReservationCommand(ReservationViewModel viewModel) {
            this.viewModel = viewModel;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return viewModel.Reservation.IsValid;
        }

        public void Execute(object parameter)
        {
            viewModel.saveReservation();
        }

        #endregion
    }
}
