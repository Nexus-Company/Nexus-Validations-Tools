// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.RequireAuthenticationAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using System;

namespace Nexus.Tools.Validations.Attributes
{
  [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
  public sealed class RequireAuthenticationAttribute : Attribute
  {
    public bool RequireValidEmail { get; set; }

    public bool ShowView { get; set; }
  }
}
