using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWpf.Model
{
    /// <summary>
    /// Model of Reservation wth data validation.
    /// </summary>
    public class Reservation : IDataErrorInfo
    {
        public int Id { get; set; }
        public int ShowingId { get; set; }
        public int RowSeatId { get; set; }
        public int Status { get; set; }
        public int CustomerId { get; set; }

        #region IDataErrorInfo Members

        public string Error
        {
            get { return null; }
        }

        public string this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        #endregion

        #region Validation

        public readonly string[] ValidateProperties =
        {
            "ShowingId",
            "RowSeatId",
        };

        public bool isValid
        {
            get
            {
                foreach (string property in ValidateProperties)
                    if (GetValidationError(property) != null)
                        return false;
                return true;
            }
        }

        string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "ShowingId":
                    error = ValidateShowingId();
                    break;
                case "RowSeatId":
                    error = ValidateRowSeatId();
                    break;
            }

            return error;
        }

        private string ValidateShowingId()
        {
            if (ShowingId == 0)
            {
                return "Wybierz seans.";
            }
            else
            {
                return null;
            }
        }

        private string ValidateRowSeatId()
        {
            if (RowSeatId == 0)
            {
                return "Wybierz miejsce.";
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
