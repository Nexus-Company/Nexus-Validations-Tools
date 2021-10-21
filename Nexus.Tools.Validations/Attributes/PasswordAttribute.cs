// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.PasswordAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;


#nullable enable
namespace Nexus.Tools.Validations.Attributes
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
  public class PasswordAttribute : ValidationAttribute
  {
    public PasswordAttribute()
    {
      this.ErrorMessage = (string) null;
      this.ErrorMessageResourceType = typeof (Errors);
      this.ErrorMessageResourceName = "PasswordValidation";
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
      if (obj == null)
        obj = (object) "";
      string str = obj.ToString();
      for (int index = 0; index < PasswordAttribute.Require.Length; ++index)
      {
        bool flag = false;
        foreach (char ch in PasswordAttribute.Require[index])
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
