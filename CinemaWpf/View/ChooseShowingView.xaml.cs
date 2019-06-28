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
    /// Interaction logic for ChooseShowing.xaml
    /// </summary>
    public partial class ChooseShowingView : Window
    {
        private static ChooseShowingView _this;

        /// <summary>
        /// Gets an object of ChooseShowingView.
        /// </summary>
        /// <returns></returns>
        public static ChooseShowingView GetInstance()
        {
            return _this;
        }

        /// <summary>
        /// Gets instance of ChooseShowingView class.
        /// </summary>
        public ChooseShowingView()
        {
            InitializeComponent();
            DataContext = new ChooseShowingViewModel();
            _this = this;
        }
    }
}
