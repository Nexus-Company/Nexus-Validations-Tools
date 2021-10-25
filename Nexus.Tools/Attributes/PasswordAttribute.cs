using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;


#nullable enable
namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Attribute for field validation containing Email.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class PasswordAttribute : ValidationAttribute
    {
        public PasswordAttribute()
        {
            ErrorMessage = (string)null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "PasswordValidation";
        }

        public static
#nullable disable
    string[] Require => new string[4]
        {
      "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
      "abcdefghijkllmnopqrstuvwxyz",
      "1234567890",
      "!@#$%¨&*()_+{`^}:?><,./\\-§=ºª"
        };

        public override bool IsValid(
#nullable enable
    object? obj)
        {
            string str;
            obj ??= string.Empty;
           
            if (obj is string rt)
            {
                str = rt;
            }
            else
            {
                str = obj.ToString();
            }

            for (int index = 0; index < Require.Length; ++index)
            {
                bool flag = false;
                foreach (char ch in Require[index])
                {
                    if (str.Contains(ch))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    return false;
            }
            return true;
        }
    }
}
