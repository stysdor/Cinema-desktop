using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWpf.ViewModel
{
    /// <summary>
    /// ViewModel for the main window. It contains uri for navigation.
    /// </summary>
    public class MainWindowViewModel
    {
        public MainWindow view;
        Uri moviesUri = new Uri("Movies.xaml", UriKind.Relative);
        Uri showingsUri = new Uri("Showings.xaml", UriKind.Relative);
        Uri reservationsUri = new Uri("Reservations.xaml", UriKind.Relative);
        Uri repertuareUri = new Uri("Repertuare.xaml", UriKind.Relative);
        Uri ticketUri = new Uri("Ticket.xaml", UriKind.Relative);
    }
} 
