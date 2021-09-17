using Nexus.Tools.Validations.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Validation for Name Attribute
    /// </summary>
    public class NameAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    { /// <summary>
      /// Constructor empty.
      /// </summary>
        public NameAttribute() : base()
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "NameValidation";
        }
        public override bool IsValid(object obj)
        {
            if (obj == null)
                return false;

            string objString = string.Empty;
            Regex rgx = new("/^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$/");

            if (obj is string result)
            {
                objString = result;
            }
            else
            {
                objString = obj.ToString();
            }

            if (!objString.Contains(" "))
                return false;

            if (rgx.IsMatch(objString))
                return true;

            return false;
        }
    }
}
