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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaWpf.View
{
    /// <summary>
    /// Interaction logic for Movies.xaml
    /// </summary>
    public partial class Movies : Page
    {
        private static Movies _this;

        /// <summary>
        /// Gets an object of Movies View.
        /// </summary>
        /// <returns></returns>
        public static Movies GetInstance()
        {
            return _this;
        }

        public Movies()
        {
            InitializeComponent();
            _this = this;
        }
    }

}
