using Nexus.Tools.Validations.Resources;

namespace Nexus.Tools.Validations.Attributes
{
    public class MinLengthAttribute : System.ComponentModel.DataAnnotations.MinLengthAttribute
    {
        public MinLengthAttribute(int min) : base(min) {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "RequiredError";
        }
    }
}
