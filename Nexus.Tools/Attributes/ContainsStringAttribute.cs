using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Validates whether the string of the object to be validated contains the string that will be fetched.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ContainsStringAttribute : ValidationAttribute
    {
        public string Value { get; set; }

        /// <summary>
        /// Initializes the attribute with the string to be fetched.
        /// </summary>
        /// <param name="value">Value to be searched.</param>
        public ContainsStringAttribute(string value)
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "ContainsValidation";
            Value = value;
        }

        public override bool IsValid(object obj)
        {
            string value;
            if (obj is string result)
            {
                value = result;
            }
            else
            {
                value = obj.ToString();
            }

            if (!value.Contains(value))
                return false;

            return true;
        }
    }
}
