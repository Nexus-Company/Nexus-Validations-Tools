using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public RequiredAttribute()
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = nameof(Errors.RequiredValidation);
        }
    }
}
