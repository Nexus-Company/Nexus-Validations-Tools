using Nexus.Tools.Validations.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Validate that the field is a valid email.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class EmailAddressAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public EmailAddressAttribute()
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "EmailValidation";
        }

        public override bool IsValid(object obj)
        {
            if (obj == null)
                return false;

            string objString = string.Empty;
            Regex rgx = new("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");

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
