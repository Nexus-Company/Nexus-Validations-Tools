// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.TimeSpanAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
  internal sealed class TimeSpanAttribute : ValidationAttribute
  {
    public long MaxTicks { get; set; }

    public TimeSpanAttribute()
    {
      this.MaxTicks = 0L;
      this.ErrorMessage = (string) null;
      this.ErrorMessageResourceName = "TimeSpanValidation";
      this.ErrorMessageResourceType = typeof (Errors);
    }

    public override bool IsValid(object value)
    {
      timeSpan = TimeSpan.FromSeconds(0.0);
      if (!(value is TimeSpan timeSpan))
        ;
      return this.MaxTicks == 0L || timeSpan.Ticks < this.MaxTicks;
    }
  }
}
