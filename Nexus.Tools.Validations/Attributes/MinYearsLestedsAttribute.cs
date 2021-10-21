// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.MinYearsLestedsAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
  public class MinYearsLestedsAttribute : ValidationAttribute
  {
    public MinYearsLestedsAttribute(int years)
    {
      this.ErrorMessage = (string) null;
      this.ErrorMessageResourceType = typeof (Errors);
      this.ErrorMessageResourceName = "MinYearsLestedsValidation";
      this.Years = years;
    }

    public int Years { get; set; }

    public override bool IsValid(object value)
    {
      if (value == null)
        return false;
      if (!(value is DateTime _))
        ;
      DateTime dateTime;
      try
      {
        dateTime = !(value is string) ? DateTime.Parse(value.ToString()) : DateTime.Parse(value as string);
      }
      catch (Exception ex)
      {
        return false;
      }
      DateTime today = DateTime.Today;
      int num = today.Year - dateTime.Year;
      if (dateTime.Date > today.AddYears(-num))
        --num;
      return num >= this.Years;
    }

    public override string FormatErrorMessage(string name) => this.ErrorMessageString.Replace("{0}", this.Years.ToString());
  }
}
