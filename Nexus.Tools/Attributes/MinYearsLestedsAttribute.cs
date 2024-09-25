using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class MinYearsLestedsAttribute : ValidationAttribute
{
    public MinYearsLestedsAttribute(int years) : base()
    {
        ErrorMessageResourceName = nameof(Errors.MinYearsLestedsValidation);
        Years = years;
    }

    public int Years { get; set; }

    public override bool IsValid(object? value)
    {
        if (value == null)
            return false;

        var dateTime = (value is DateTime date) ? date : DateTime.MinValue;

        try
        {
            dateTime = value is string str ? DateTime.Parse(str) : DateTime.Parse(value?.ToString() ?? string.Empty);
        }
        catch (Exception)
        {
            return false;
        }

        DateTime today = DateTime.Today;
        int num = today.Year - dateTime.Year;

        if (dateTime.Date > today.AddYears(-num))
            --num;

        return num >= Years;
    }

    public override string FormatErrorMessage(string name) => ErrorMessageString.Replace("{0}", Years.ToString());
}
