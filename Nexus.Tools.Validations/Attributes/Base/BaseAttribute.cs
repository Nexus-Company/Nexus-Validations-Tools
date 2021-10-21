// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.Base.BaseAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes.Base
{
  public class BaseAttribute : ValidationAttribute
  {
    public override string FormatErrorMessage(string name) => this.FormatStringMessage(name, string.Empty);

    protected internal string FormatStringMessage(string name, string displayName) => base.FormatErrorMessage(name);
  }
}
