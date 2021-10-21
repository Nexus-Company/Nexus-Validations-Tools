using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Nexus.Tools.Validations.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class EmailAddressAttribute : ValidationAttribute
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
            string empty = string.Empty;
            return new Regex("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$").IsMatch(!(obj is string str) ? obj.ToString() : str);
        }
    }
}
