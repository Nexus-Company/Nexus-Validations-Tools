using Nexus.Tools.Validations.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Attributes
{
    public class PhoneAttribute : ValidationAttribute
    {
        public PhoneAttribute() : base() {
            ErrorMessage = null;  
            ErrorMessageResourceType = typeof(Errors); 
            ErrorMessageResourceName = "PhoneValidation";
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
    }
}
