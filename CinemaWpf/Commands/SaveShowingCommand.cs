using CinemaWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CinemaWpf.Commands
{
    internal class SaveShowingCommand : ICommand
    {
        private ShowingViewModel viewModel;

        /// <summary>
        /// Initialize a new instance of the SaveShowingCommand class.
        /// </summary>
        /// <param name="viewModel"></param>
        public SaveShowingCommand(ShowingViewModel viewModel) {
            this.viewModel = viewModel;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return viewModel.Showing.isValid;
        }

        public void Execute(object parameter)
        {
            viewModel.saveShowing();
        }

        #endregion
    }
}
