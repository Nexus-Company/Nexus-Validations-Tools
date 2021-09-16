using Nexus.Tools.Validations.Resources;

namespace Nexus.Tools.Validations.Attributes
{
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public RequiredAttribute()
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "RequiredError";
        }
    }
}
