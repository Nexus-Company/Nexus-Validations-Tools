using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes
{
    public class UrlAttribute : ValidationAttribute
    {

        public UrlAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Errors.UrlValidation);
        }
        public override bool IsValid(object value)
        {
            string str = string.Empty;

            if (value is string isStr)
                str = isStr;

            if (value is not string)
            {
                str = value.ToString();

                if (value is Uri)
                    return true;
            }

            bool result = Uri.TryCreate(str, UriKind.Absolute, out Uri uriResult)
                && (string.IsNullOrEmpty(uriResult.Scheme) || uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }
    }
}


