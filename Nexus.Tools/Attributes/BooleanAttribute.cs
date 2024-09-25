using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;

namespace Nexus.Tools.Validations.Attributes;

/// <summary>
/// Validate a Boolean attribute
/// </summary>
public class BooleanAttribute : ValidationAttribute
{
    /// <summary>
    /// True value only
    /// </summary>
    public bool TrueOnly { get; set; }

    /// <summary>
    /// False value only
    /// </summary>
    public bool FalseOnly { get; set; }

    /// <summary>
    /// Constrcutor for BooleanAttribute
    /// </summary>
    public BooleanAttribute() : base()
    {
        ErrorMessageResourceName = nameof(Errors.BooleanValidation);
    }

    public override bool IsValid(object? value)
    {
        value ??= false;
        bool bValue = false;

        if (value is bool bv)
            bValue = bv;

        if (bValue && TrueOnly)
            return true;

        if (!bValue && FalseOnly)
            return true;

        return false;
    }
}