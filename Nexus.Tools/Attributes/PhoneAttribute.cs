using Nexus.Tools.Validations.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Validates that the field contains an object with the value of a valid number.
    /// </summary>
    public class PhoneAttribute : ValidationAttribute
    {
        /// <summary>
        /// Constructor empty.
        /// </summary>
        public PhoneAttribute() : base() {
            ErrorMessage = null;  
            ErrorMessageResourceType = typeof(Errors); 
            ErrorMessageResourceName = "PhoneValidation";
        }

        public override bool IsValid(object obj)
        {
            string objString = string.Empty;
            Regex rgx = new("^(?:(?:\\+|00)?(55)\\s?)?(?:\\(?([1-9][0-9])\\)?\\s?)?(?:((?:9\\d|[2-9])\\d{3})\\-?(\\d{4}))$");

            if (obj is string result)
            {
                objString = result;
            }
            else
            {
                objString = obj.ToString();
            }

            if (rgx.IsMatch(objString))
                return true;

            return false;
        }
    }
}
