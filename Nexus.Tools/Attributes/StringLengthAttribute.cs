using Nexus.Tools.Validations.Resources;

namespace Nexus.Tools.Validations.Attributes
{
    public class StringLengthAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute
    {
        public StringLengthAttribute(int max) : base(max)
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "StringLengthValidation";
        }
    }
}
