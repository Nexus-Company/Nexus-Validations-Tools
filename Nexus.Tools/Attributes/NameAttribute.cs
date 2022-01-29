using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;
using System;
using System.Text.RegularExpressions;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Validates if the field contains a name in the with numeric alpha characters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class NameAttribute : ValidationAttribute
    {
        public NameAttribute()
        {
            ErrorMessageResourceName = nameof(Errors.NameValidation);
        }

        public override bool IsValid(object obj)
        {
            if (obj == null)
                return false;

            Regex regex = new("^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ' ]+$");

            string input = obj is not string str ? obj.ToString() : str;

            return input.Contains(' ') && regex.IsMatch(input);
        }
    }
}
