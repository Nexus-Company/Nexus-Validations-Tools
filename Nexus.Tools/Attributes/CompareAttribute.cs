using Nexus.Tools.Validations.Resources;

namespace Nexus.Tools.Validations.Attributes
{
    public class CompareAttribute : System.ComponentModel.DataAnnotations.CompareAttribute
    {
        public CompareAttribute(string field) : base(field)
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "CompareValidation";
        }
    }
}
