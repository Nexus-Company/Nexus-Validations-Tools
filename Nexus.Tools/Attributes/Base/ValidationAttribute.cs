using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes.Base
{/// <summary>
 /// Basic Validation Attribute Class
 /// </summary>
    public class ValidationAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override string FormatErrorMessage(string name) => FormatStringMessage(name, string.Empty);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        protected internal string FormatStringMessage(string name, string displayName) => base.FormatErrorMessage(name);
    }
}
