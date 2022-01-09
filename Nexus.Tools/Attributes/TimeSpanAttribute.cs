using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class TimeSpanAttribute : ValidationAttribute
    {
        public long MaxTicks { get; set; }
        public TimeSpanAttribute() : base()
        {
            MaxTicks = 0;
            ErrorMessageResourceName = nameof(Errors.TimeSpanValidation);
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
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
