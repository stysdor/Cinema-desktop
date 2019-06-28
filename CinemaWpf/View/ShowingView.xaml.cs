using CinemaWpf.Model;
using CinemaWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Windows;

namespace CinemaWpf.View
{
    /// <summary>
    /// Interaction logic for ShowingView.xaml
    /// </summary>
    public partial class ShowingView : Window
    {
        private static ShowingView _this;

        /// <summary>
        /// Gets an object of ChooseShowingView.
        /// </summary>
        /// <returns></returns>
        public static ShowingView GetInstance()
        {
            return _this;
        }

        public ShowingView()
        {
            InitializeComponent();
            _this = this;
        }

        public ShowingView(Showing model)
        {
            InitializeComponent();
            DataContext = new ShowingViewModel(model);
            _this = this;
        }
    }
}
