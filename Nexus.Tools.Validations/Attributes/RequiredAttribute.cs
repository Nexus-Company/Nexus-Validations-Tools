// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.RequiredAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
  public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
  {
    public RequiredAttribute()
    {
      this.ErrorMessage = (string) null;
      this.ErrorMessageResourceType = typeof (Errors);
      this.ErrorMessageResourceName = "RequiredValidation";
    }
  }
}
