// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.CompareAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// 
    /// </summary>
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
  public class CompareAttribute : System.ComponentModel.DataAnnotations.CompareAttribute
  {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
    public CompareAttribute(string field)
      : base(field)
    {
      ErrorMessage = (string) null;
      ErrorMessageResourceType = typeof (Errors);
      ErrorMessageResourceName = "CompareValidation";
    }

    public override string FormatErrorMessage(string name) => ErrorMessageString.Replace("{0}", OtherPropertyDisplayName);
  }
}
