using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWpf.Model
{
    /// <summary>
    /// Model of Showing with data validation.
    /// </summary>
    public class Showing : IDataErrorInfo
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int TheatreId { get; set; }
        public DateTime ShowingDateTime { get; set; }

        /// <summary>
        /// Gets only date from ShowingDateTime
        /// </summary>
        public string ShowingDate
        {
            get { return showDate(ShowingDateTime); }
        }

        /// <summary>
        /// Gets only time from ShowngDateTime.
        /// </summary>
        public string ShowingHour
        {
            get { return showHour(ShowingDateTime); }
        }

        public string showHour(DateTime dateTime) {
            return dateTime.ToString("HH:mm");
        }

        /// <summary>
        /// Changes ShowingDateTime to string with the right format.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public string showDate(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }

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
            "MovieId",
            "TheatreId",
            "ShowingDateTime"
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
                case "MovieId":
                    error = ValidateShowingId();
                    break;
                case "TheatreId":
                    error = ValidateTheatreId();
                    break;
                case "ShowingDateTime":
                    error = ValidateShowingDateTime();
                    break;
            }

            return error;
        }

        private string ValidateShowingId()
        {
            if (MovieId == 0)
            {
                return "Wybierz film.";
            }
            else
            {
                return null;
            }
        }

        private string ValidateTheatreId()
        {
            if (TheatreId == 0)
            {
                return "Wybierz sale.";
            }
            else
            {
                return null;
            }
        }

        private string ValidateShowingDateTime()
        {
            if (ShowingDateTime.GetType() != typeof(DateTime))
            {
                return "Wprowadź poprawny format daty.";
            }

            else if (ShowingDateTime < DateTime.Now)
            {
                return "Nie można wprowadzić seansu, który już się odbył.";
            }
            else
            {
                return null;
            }
        }
        #endregion

    }
}
