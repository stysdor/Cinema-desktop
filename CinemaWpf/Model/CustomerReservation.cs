using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CinemaWpf.Model
{
    /// <summary>
    /// Model for view connected with both: Reservation and Customer model.
    /// </summary>
    public class CustomerReservation
    {
        public Reservation Reservation { get; set; }
        public Customer Customer { get; set; }

        /// <summary>
        /// Initialises an instance of CustomerReservation class.
        /// </summary>
        public CustomerReservation()
        {
            Reservation = new Reservation();
            Customer = new Customer();
        }

        /// <summary>
        /// Checks if Model of both: Customer and Reservation is valid.
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (Reservation.isValid && Customer.isValid)
                    return true;
                else return false;
            }
        }
    }
}
