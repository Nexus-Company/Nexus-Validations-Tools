using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class TimeSpanAttribute : ValidationAttribute
    {
        public long MaxTicks { get; set; }
        public TimeSpanAttribute()
        {
            MaxTicks = 0;
            ErrorMessage = null;
            ErrorMessageResourceName = "TimeSpanValidation";
            ErrorMessageResourceType = typeof(Errors);
        }
        public override bool IsValid(object value)
        {
            TimeSpan tmValue = TimeSpan.FromSeconds(0);

            if (value is TimeSpan span)
            {
                tmValue = span;
            }

            if (MaxTicks != 0)
            {
                if (tmValue.Ticks < MaxTicks)
                    return true;
                ErrorMessage = $"The time space and greater than {TimeSpan.FromTicks(MaxTicks)}.";
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
