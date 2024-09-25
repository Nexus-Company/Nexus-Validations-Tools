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

    public override bool IsValid(object value)
    {
        if (value == null)
            return false;

        var dateTime = (value is DateTime date) ? date : DateTime.MinValue;

        try
        {
            dateTime = value is not string ? DateTime.Parse(value.ToString()) : DateTime.Parse(value as string);
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
