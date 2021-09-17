using Nexus.Tools.Validations.Resources;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Defines that the value of the object in the attribute cannot be null and must be set.
    /// </summary>
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        /// <summary>
        /// Constructor of Attribute.
        /// </summary>
        public RequiredAttribute()
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "RequiredValidation";
        }
    }
}
