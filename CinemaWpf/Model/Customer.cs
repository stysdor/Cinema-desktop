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
    /// Model of Customer with data validation.
    /// </summary>
    public class Customer : IDataErrorInfo
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

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
            "CustomerName",
            "CustomerSurname",
            "Email",
            "Phone"
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
                case "CustomerName":
                    error = ValidateCustomerName();
                    break;
                case "CustomerSurname":
                    error = ValidateCustomerSurname();
                    break;
                case "Email":
                    error = ValidateEmail();
                    break;
                case "Phone":
                    error = ValidatePhone();
                    break;
            }

            return error;
        }

        private string ValidateCustomerName()
        {
            if (String.IsNullOrWhiteSpace(CustomerName))
            {
                return "Imię nie może być puste.";
            }
            else if (CustomerName.Length < 3 || CustomerName.Length > 50)
            {
                return "Imię musi mieć więcej niź 2 znaki i nie więcej niż 50.";
            }
            else
            {
                return null;
            }
        }

        private string ValidateCustomerSurname()
        {
            if (String.IsNullOrWhiteSpace(CustomerSurname))
            {
                return "Nazwisko nie może być puste.";
            }
            else if (CustomerSurname.Length < 3 || CustomerSurname.Length > 50)
            {
                return "Nazwisko musi mieć więcej niź 2 znaki i nie więcej niż 50.";
            }
            else
            {
                return null;
            }
        }

        private string ValidateEmail()
        {
            if (String.IsNullOrWhiteSpace(Email))
                return null;
            else
                return IsValidEmailAddress(Email) ? null : "Podaj poprawny adres email.";
        }

        private string ValidatePhone()
        {
            if (String.IsNullOrWhiteSpace(Phone))
                return null;
            else
                return IsValidPhoneNumber(Phone) ? null : "Podaj poprawny numer telefonu.";
        }

        private bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return regex.IsMatch(s);
        }

        private bool IsValidPhoneNumber(string number)
        {
            return Regex.Match(number, @"^([+]?([0-9]{2})?[0-9]{9})$").Success;
        }

        #endregion
    }
}
 