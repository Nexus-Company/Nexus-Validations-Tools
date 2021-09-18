using Nexus.Tools.Validations.Resources;

namespace Nexus.Tools.Validations.Attributes
{
    public class StringLengthAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute
    {
        public StringLengthAttribute(int max) : base(max)
        {
            Text ??= string.Empty;
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "StringLengthValidation";
        }
        private string Text { get; set; }
        public override string FormatErrorMessage(string name)
        {
            if (Text.Length < MinimumLength &&
                ErrorMessageResourceName != null &&
                ErrorMessageResourceType != null)
            {
                if (ErrorMessageResourceName == "StringLengthValidation" &&
                ErrorMessageResourceType.FullName == typeof(Errors).FullName)
                    ErrorMessageResourceName = "SmallStringLengthValidation";
            }

            return ErrorMessageString.Replace("{1}", MinimumLength.ToString()).Replace("{0}", MaximumLength.ToString());
        }

        public override bool IsValid(object value)
        {
            Text = string.Empty;
            if (value != null)
            {
                if (value is string text)
                {
                    Text = text;
                }
                else
                {
                    Text = value.ToString();
                }
            }
            return base.IsValid(value);
        }
    }
}
