using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWpf.Model
{
    /// <summary>
    /// Model of RowSeat.
    /// </summary>
    public class RowSeat
    {
        public int Id { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public Status SeatStatus { get; set; }

        public enum Status { Free, Reserved, Sold }

        /// <summary>
        /// Returns RowNumber changed to string.
        /// </summary>
        public string RowName
        {
            get { return RowNumber.ToString(); }
        }

        /// <summary>
        /// Return id changed into string.
        /// </summary>
        public string SeatName
        {
            get { return Id.ToString(); }
        }
    }
}
