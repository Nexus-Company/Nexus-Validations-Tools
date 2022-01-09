using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal sealed class MaxDateAttribute : ValidationAttribute
    {
        public long MaxTicks { get; set; }

        public MaxDateAttribute(long max) : base()
        {
            MaxTicks = max;
            ErrorMessage = string.Format("The time space and greater than {0}.", (object)TimeSpan.FromTicks(MaxTicks));
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            return value is TimeSpan timeSpan && timeSpan.Ticks < MaxTicks || base.IsValid(value);
        }
    }
}
