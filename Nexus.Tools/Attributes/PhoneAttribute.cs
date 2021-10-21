// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.PhoneAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Nexus.Tools.Validations.Attributes
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
  public class PhoneAttribute : ValidationAttribute
  {
    public PhoneAttribute()
    {
      ErrorMessage = (string) null;
      ErrorMessageResourceType = typeof (Errors);
      ErrorMessageResourceName = "PhoneValidation";
    }

    public override bool IsValid(object obj)
    {
      if (obj == null)
        return false;
      string empty = string.Empty;
      return new Regex("^(?:(?:\\+|00)?(55)\\s?)?(?:\\(?([1-9][0-9])\\)?\\s?)?(?:((?:9\\d|[2-9])\\d{3})\\-?(\\d{4}))$").IsMatch(!(obj is string str) ? obj.ToString() : str);
    }
  }
}
