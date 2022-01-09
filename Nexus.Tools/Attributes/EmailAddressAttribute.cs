using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;
using System;
using System.Text.RegularExpressions;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Attribute for field validation containing EmailAdress.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class EmailAddressAttribute : ValidationAttribute
    {
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public EmailAddressAttribute()
        {
            ErrorMessageResourceName = nameof(Errors.EmailValidation);
        }

        public override bool IsValid(object obj)
        {
            if (obj == null)
                return false;

            return new Regex("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$").IsMatch((obj is not string str) ? obj.ToString() : str);
        }
    }
}
