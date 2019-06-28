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

namespace CinemaWpf.View
{
    /// <summary>
    /// Interaction logic for MovieView.xaml
    /// </summary>
    public partial class MovieView : Window
    {
        private static MovieView _this;

        /// <summary>
        /// Gets an object of MovieView.
        /// </summary>
        /// <returns></returns>
        public static MovieView GetInstance()
        {
            return _this;
        }

        public MovieView()
        {
            InitializeComponent();
            DataContext = new MovieViewModel();
            _this = this;
        }

        public MovieView(Movie model)
        {
            InitializeComponent();
            DataContext = new MovieViewModel(model);
            _this = this;
        }
    }
}
