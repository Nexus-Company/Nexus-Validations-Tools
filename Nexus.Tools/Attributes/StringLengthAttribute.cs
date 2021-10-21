// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.StringLengthAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
  public class StringLengthAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute
  {
    public StringLengthAttribute(int max)
      : base(max)
    {
      if (Text == null)
      {
        string empty;
        Text = empty = string.Empty;
      }
      ErrorMessage = (string) null;
      ErrorMessageResourceType = typeof (Errors);
      ErrorMessageResourceName = "StringLengthValidation";
    }

    private string Text { get; set; }

    public override string FormatErrorMessage(string name)
    {
      if (Text.Length < MinimumLength && ErrorMessageResourceName != null && ErrorMessageResourceType != (Type) null && ErrorMessageResourceName == "StringLengthValidation" && ErrorMessageResourceType.FullName == typeof (Errors).FullName)
        ErrorMessageResourceName = "SmallStringLengthValidation";
      return ErrorMessageString.Replace("{1}", MinimumLength.ToString()).Replace("{0}", MaximumLength.ToString());
    }

    public override bool IsValid(object value)
    {
      Text = string.Empty;
      if (value != null)
        Text = !(value is string str2) ? value.ToString() : str2;
      return base.IsValid(value);
    }
  }
}
