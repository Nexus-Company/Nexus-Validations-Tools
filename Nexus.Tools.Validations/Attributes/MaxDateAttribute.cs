// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.MaxDateAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  internal sealed class MaxDateAttribute : ValidationAttribute
  {
    public long MaxTicks { get; set; }

    public MaxDateAttribute(long max)
    {
      this.MaxTicks = max;
      this.ErrorMessage = string.Format("The time space and greater than {0}.", (object) TimeSpan.FromTicks(this.MaxTicks));
    }

    public override bool IsValid(object value)
    {
      if (value == null)
        return false;
      return value is TimeSpan timeSpan && timeSpan.Ticks < this.MaxTicks || base.IsValid(value);
    }
  }
}
