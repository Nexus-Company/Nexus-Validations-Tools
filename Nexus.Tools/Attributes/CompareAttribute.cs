using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Comparts whether the value of two fields are equal.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class CompareAttribute : System.ComponentModel.DataAnnotations.CompareAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="field">Name of validation field</param>
        public CompareAttribute(string field)
          : base(field)
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = nameof(Errors.CompareValidation);
        }

        public override string FormatErrorMessage(string name) => ErrorMessageString.Replace("{0}", OtherPropertyDisplayName);
    }
}
