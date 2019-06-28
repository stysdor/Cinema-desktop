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

namespace CinemaWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.pageFrame.Source = repertuareUri;
        }

        //I know it's not the best practise, but it's quick and I don't have enough time.
        //In the future I'll remove these lines and use commands implementing ICommand interfaces in ViewModel instead.
        Uri moviesUri = new Uri("Movies.xaml", UriKind.Relative);
        Uri showingsUri = new Uri("Showings.xaml", UriKind.Relative);
        Uri reservationsUri = new Uri("Reservations.xaml", UriKind.Relative);
        Uri repertuareUri = new Uri("Repertuare.xaml", UriKind.Relative);
        Uri ticketUri = new Uri("Ticket.xaml", UriKind.Relative);

        private void RepertuareButton_Click(object sender, RoutedEventArgs e)
        { 
            this.pageFrame.Source = repertuareUri;
        }

        private void TicketsButton_Click(object sender, RoutedEventArgs e)
        {
            //Buying a ticket equals confirmation a reservation. In the future it will generate a ticket for the customer.
            this.pageFrame.Source = reservationsUri;
        }

        private void MoviesButton_Click(object sender, RoutedEventArgs e)
        {
            this.pageFrame.Source = moviesUri;
        }

        private void ShowingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.pageFrame.Source = showingsUri;
        }

        private void ReservationsButton_Click(object sender, RoutedEventArgs e)
        {
            this.pageFrame.Source = reservationsUri;
        }
    }
}
