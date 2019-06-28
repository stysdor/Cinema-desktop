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

namespace CinemaWpf.View
{
    /// <summary>
    /// Interaction logic for ChooseMovieView.xaml
    /// </summary>
    public partial class ChooseMovieView : Window
    {
        private static ChooseMovieView _this;

        /// <summary>
        /// Gets an object of ChooseMovieView.
        /// </summary>
        /// <returns></returns>
        public static ChooseMovieView GetInstance()
        {
            return _this;
        }

        public ChooseMovieView()
        {
            InitializeComponent();
            DataContext = new ChooseMovieViewModel();
            _this = this;
        }
    }
}
