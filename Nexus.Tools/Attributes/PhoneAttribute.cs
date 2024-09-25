using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;
using System;
using System.Text.RegularExpressions;

namespace Nexus.Tools.Validations.Attributes;

/// <summary>
/// Phone Validation Attribute
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public sealed partial class PhoneAttribute : ValidationAttribute
{
    public PhoneAttribute()
    {
        ErrorMessageResourceName = nameof(Errors.PhoneValidation);
    }

    public override bool IsValid(object? obj)
    {
        if (obj == null)
            return false;

        return PhoneNumRegex()
            .IsMatch((obj is string str) ? str : (obj?.ToString() ?? string.Empty));
    }

    [GeneratedRegex("^(?:(?:\\+|00)?(55)\\s?)?(?:\\(?([1-9][0-9])\\)?\\s?)?(?:((?:9\\d|[2-9])\\d{3})\\-?(\\d{4}))$")]
    private static partial Regex PhoneNumRegex();
}
