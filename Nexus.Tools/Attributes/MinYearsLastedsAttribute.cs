using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Validates that the difference between the current date and the start date and greater than the amount of time set.
    /// </summary>
    public class MinYearsLestedsAttribute : ValidationAttribute
    {
        /// <summary>
        /// Initialize the attribute with the minimum time in years.
        /// </summary>
        /// <param name="years">Minimum years.</param>
        public MinYearsLestedsAttribute(int years)
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "MinYearsLestedsValidation";
            Years = years;
        }
        /// <summary>
        /// Minimum years.
        /// </summary>
        public int Years { get; set; }
        public override bool IsValid(object value)
        {
            DateTime date;

            if (value ==null)
                return false;
            
            if (value is DateTime time)
            {
                date = time;
            }

            try
            {
                if (value is string)
                {
                    date = DateTime.Parse(value as string);
                }
                else
                {
                    date = DateTime.Parse(value.ToString());
                }
            }
            catch (Exception)
            {
                return false;
            }

            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - date.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (date.Date > today.AddYears(-age)) age--;

            if (age<Years)
                return false;

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return ErrorMessageString.Replace("{0}", Years.ToString());
        }
    }
}
