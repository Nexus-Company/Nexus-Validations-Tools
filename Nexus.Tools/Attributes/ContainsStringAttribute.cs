// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.ContainsStringAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public sealed class ContainsStringAttribute : ValidationAttribute
    {/// <summary>
     /// 
     /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>

        public ContainsStringAttribute(string value)
        {
            ErrorMessage = (string)null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "ContainsValidation";
            Value = value;
        }

        public override bool IsValid(object obj)
        {
            if (obj == null)
                return false;
            string str1 = !(obj is string str2) ? obj.ToString() : str2;
            return str1.Contains(str1);
        }
    }
}
