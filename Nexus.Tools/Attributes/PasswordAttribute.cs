using Nexus.Tools.Validations.Resources;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Sets the field as a password and searches for the parameters in the password.
    /// </summary>
    public class PasswordAttribute : ValidationAttribute
    {/// <summary>
     /// Empty constructor.
     /// </summary>
        public PasswordAttribute()
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "PasswordValidation";
        }
        /// <summary>
        /// Array of strings where the password must contain at least one character of each line of the array.
        /// </summary>
        public static string[] Require
        {
            get => new string[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "abcdefghijkllmnopqrstuvwxyz",
            "1234567890",
            @"!@#$%¨&*()_+{`^}:?><,./\-§=ºª" };
        }
        public override bool IsValid(object? obj)
        {
            obj ??= "";

            string str = obj.ToString();
            for (int i = 0; i < Require.Length; i++)
            {
                bool contains = false;
                foreach (char letter in Require[i])
                {
                    if (str.Contains(letter))
                    {
                        contains = true;
                        break;
                    }
                }

                if (!contains)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
