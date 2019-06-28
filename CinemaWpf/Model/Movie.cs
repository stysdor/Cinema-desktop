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
    /// Model of Movie with data validation.
    /// </summary>
    public class Movie : IDataErrorInfo
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDescription { get; set; }
        public string CategoryName { get; set; }
        public string Country { get; set; }
        public string YearOfProduction { get; set; }

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
            "MovieTitle",
            "MovieDescription",
            "CategoryName",
            "Country",
            "YearOfProduction"
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
                case "MovieTitle":
                    error = ValidateMovieTitle();
                    break;
                case "MovieDescription":
                    error = ValidateMovieDescription();
                    break;
                case "CategoryName":
                    error = ValidateCategoryName();
                    break;
                case "Country":
                    error = ValidateCountry();
                    break;
                case "YearOfProduction":
                    error = ValidateYearOfProduction();
                    break;
            }

            return error;
        }

        private string ValidateMovieTitle()
        {
            if (String.IsNullOrWhiteSpace(MovieTitle))
            {
                return "Tytuł nie może być pusty";
            }
            else if (MovieTitle.Length < 3 || MovieTitle.Length > 50)
            {
                return "Tytuł musi mieć więcej niź 2 znaki i nie więcej niż 50.";
            }
            else
            {
                return null;
            }
        }

        private string ValidateMovieDescription()
        {
            if (String.IsNullOrWhiteSpace(MovieDescription))
            {
                return "Opis nie może być pusty";
            }
            else if (MovieDescription.Length < 3)
            {
                return "Opis musi mieć więcej niź 2 znaki.";
            }
            else
            {
                return null;
            }
        }

        private string ValidateCategoryName()
        {
            if (String.IsNullOrWhiteSpace(CategoryName))
            {
                return "Kategoria nie może być pusta.";
            }
            else if (CategoryName.Length < 3 || CategoryName.Length > 50)
            {
                return "Kategoria musi mieć więcej niź 2 znaki i mniej niż 50.";
            }
            else
            {
                return null;
            }
        }

        private string ValidateCountry()
        {
            if (String.IsNullOrWhiteSpace(Country))
            {
                return "Kraj nie może być pusty.";
            }
            else if (Country.Length < 3 || Country.Length > 50)
            {
                return "Kraj musi mieć więcej niź 2 znaki i mniej niż 50.";
            }
            else
            {
                return null;
            }
        }

        private string ValidateYearOfProduction()
        {
            if (String.IsNullOrWhiteSpace(YearOfProduction))
            {
                return "Rok nie może być pusty.";
            }
            else if (!IsValidYear(YearOfProduction))
            {
                return "Wprowadź poprawny rok.";
            }
            else
            {
                return null;
            }
        }

        private bool IsValidYear(string number)
        {
            return Regex.Match(number, @"^([0-9]{4})$").Success;
        }

        #endregion

    }
}
