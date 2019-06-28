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
    /// Interaction logic for ReservationView.xaml
    /// </summary>
    public partial class ReservationView : Window
    {
        private static ReservationView _this;

        /// <summary>
        /// Gets an object of ReservationView.
        /// </summary>
        /// <returns></returns>
        public static ReservationView GetInstance()
        {
            return _this;
        }

        /// <summary>
        /// Initialize an instance of ReservationView class.
        /// </summary>
        public ReservationView()
        {
            InitializeComponent();
            _this = this;
        }

        /// <summary>
        /// Initialize an instance of ReservationView class.
        /// </summary>
        /// <param name="model">Model of CustomerReservation Class.</param>
        public ReservationView(CustomerReservation model)
        {
            InitializeComponent();
            DataContext = new ReservationViewModel(model);
            _this = this;
        }
    }
}
