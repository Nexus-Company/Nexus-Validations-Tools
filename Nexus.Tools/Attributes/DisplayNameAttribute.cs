// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.DisplayNameAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using System;


#nullable enable
namespace Nexus.Tools.Validations.Attributes
{
  public class DisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
  {
    private string? _displayName;

    public DisplayNameAttribute(
    #nullable disable
    string displayName) => _displayName = displayName;

    public DisplayNameAttribute(Type resourceType, string resourceName)
    {
      ResourceType = resourceType;
      ResourceName = resourceName;
    }

    public override string DisplayName
    {
      get
      {
        if (_displayName != null)
          return _displayName;
        if (ResourceName == null || !(ResourceType != (Type) null))
          return string.Empty;
        object obj = ResourceType.GetProperty(ResourceName).GetValue((object) null, (object[]) null);
        return obj is string str ? str : obj.ToString();
      }
    }

    public 
    #nullable enable
    Type? ResourceType { get; set; }

    public string? ResourceName { get; set; }
  }
}
