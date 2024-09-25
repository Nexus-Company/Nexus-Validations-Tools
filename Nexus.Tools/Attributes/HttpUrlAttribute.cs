using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes;

public class HttpUrlAttribute : ValidationAttribute
{
    public bool HttpsOnly { get; set; } = false;

    public HttpUrlAttribute() 
        : base()
    {
        ErrorMessageResourceName = nameof(Errors.HttpUrlValidation);
    }

    public override bool IsValid(object? value)
    {
        string str = string.Empty;

        if (value is string isStr)
            str = isStr;

        if (value is not string)
        {
            str = value?.ToString() ?? string.Empty;

            if (value is Uri)
                return true;
        }

        bool result = Uri.TryCreate(str, UriKind.Absolute, out Uri? uriResult) &&
            uriResult != null && 
            (string.IsNullOrWhiteSpace(uriResult.Scheme) || (uriResult.Scheme == Uri.UriSchemeHttp && !HttpsOnly) || uriResult.Scheme == Uri.UriSchemeHttps);

        return result;
    }
}