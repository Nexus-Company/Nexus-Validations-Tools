using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class CompareAttribute : System.ComponentModel.DataAnnotations.CompareAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        public CompareAttribute(string field)
          : base(field)
        {
            ErrorMessage = (string)null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "CompareValidation";
        }

        public override string FormatErrorMessage(string name) => ErrorMessageString.Replace("{0}", OtherPropertyDisplayName);
    }
}
