using Cinema.Infrastructure.Dto;
using CinemaWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWpf.ViewModel
{
    /// <summary>
    /// Class with data for displaying reservation and customer together.
    /// </summary>
    public class CustomerReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public Customer Customer { get; set; }

        public IList<RowSeatDto> Seats { get; set; }
    }
}
