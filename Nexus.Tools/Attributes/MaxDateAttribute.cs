using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    sealed class MaxDateAttribute : ValidationAttribute
    {
        public long MaxTicks { get; set; }
        public MaxDateAttribute(long max)
        {
            MaxTicks = max;
            ErrorMessage = $"The time space and greater than {TimeSpan.FromTicks(MaxTicks)}.";
        }

        public override bool IsValid(object value)
        {
            if (value is TimeSpan timeSpan)
            {
                if (timeSpan.Ticks < MaxTicks)
                    return true;
            }

            return base.IsValid(value);
        }
    }
}