using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;
using System;
using System.Text.RegularExpressions;

namespace Nexus.Tools.Validations.Attributes;


/// <summary>
/// Validates if the field contains a name in the with numeric alpha characters.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public partial class NameAttribute : ValidationAttribute
{
    public NameAttribute()
    {
        ErrorMessageResourceName = nameof(Errors.NameValidation);
    }

    public override bool IsValid(object? obj)
    {
        if (obj == null)
            return false;

        string input = (obj is string str) ? str : (obj?.ToString() ?? string.Empty);

        return input.Contains(' ') && NameValidation().IsMatch(input);
    }

    [GeneratedRegex("^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ' ]+$")]
    private static partial Regex NameValidation();
}