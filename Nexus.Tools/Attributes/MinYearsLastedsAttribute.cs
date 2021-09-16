using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
    public class MinYearsLastedsAttribute : ValidationAttribute
    {
        public MinYearsLastedsAttribute()
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "BirthdayValidation";
        }
        public int Years { get; set; }
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                const double ApproxDaysPerYear = 365.25;
                if ((DateTime.UtcNow - date).TotalDays < (ApproxDaysPerYear * Years))
                {
                    return false;
                }
            }

            return false;
        }
    }
}
