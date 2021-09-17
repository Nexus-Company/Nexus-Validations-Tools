using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Comparts whether the value of two fields are equal.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class CompareAttribute : System.ComponentModel.DataAnnotations.CompareAttribute
    {
        /// <summary>
        /// Boots with the field name.
        /// </summary>
        /// <param name="field">Name of the field to be compared.</param>
        public CompareAttribute(string field) : base(field)
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "CompareValidation";
        }
       
        public override string FormatErrorMessage(string name)
        {
            return ErrorMessageString.Replace("{0}", name);
        }
    }
}
