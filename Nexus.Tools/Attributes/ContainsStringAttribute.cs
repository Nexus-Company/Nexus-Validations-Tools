using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public sealed class ContainsStringAttribute : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ContainsStringAttribute(string value) : base()
        {
            ErrorMessageResourceName = nameof(Errors.ContainsValidation);
            Value = value;
        }

        public override bool IsValid(object obj)
        {
            if (obj == null)
                return false;

            string? str1 = (obj is not string str2) ? obj.ToString() : str2;

            return (str1 ?? string.Empty).Contains(Value);
        }
    }
}
