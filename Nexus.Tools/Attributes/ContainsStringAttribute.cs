using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ContainsStringAttribute : ValidationAttribute
    {
        public string[] Values { get; set; }
        public ContainsStringAttribute(string[] values)
        {
            Values = values;
        }

        public override bool IsValid(object obj)
        {
            string value;
            if (obj is string result)
            {
                value = result;
            }
            else
            {
                value = obj.ToString();
            }

            foreach (string item in Values)
            {
                if (!value.Contains(item))
                {
                    ErrorMessage = $"The string not contains: {item}";
                    return false;
                }
            }

            return base.IsValid(value);
        }
    }
}
