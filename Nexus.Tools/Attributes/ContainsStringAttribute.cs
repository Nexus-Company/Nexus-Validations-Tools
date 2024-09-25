using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
public sealed class ContainsStringAttribute : ValidationAttribute
{
    public string Value { get; set; }

    public ContainsStringAttribute(string value) : base()
    {
        ErrorMessageResourceName = nameof(Errors.ContainsValidation);
        Value = value;
    }

    public override bool IsValid(object? obj)
    {
        if (obj == null)
            return false;

        string? str = (obj is not string strConvert) ? obj.ToString() : strConvert;

        return (str ?? string.Empty).Contains(Value);
    }
}