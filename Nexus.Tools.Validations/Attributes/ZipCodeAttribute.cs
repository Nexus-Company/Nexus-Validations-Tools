// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.ZipCodeAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Attributes
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public class ZipCodeAttribute : ValidationAttribute
  {
    public ZipCodeAttribute()
    {
      this.ErrorMessage = (string) null;
      this.ErrorMessageResourceType = typeof (Errors);
      this.ErrorMessageResourceName = "ZipCodeValidation";
    }

    public override bool IsValid(object value)
    {
      if (value == null)
        return false;
      Task<HttpResponseMessage> async = new HttpClient().GetAsync("https://open-cep.azurewebsites.net/api/Cep/ByNumber?number=" + Regex.Replace(value.ToString(), "[^0-9]+", string.Empty));
      async.Wait();
      if (async.Result.StatusCode != HttpStatusCode.OK)
        return false;
      Task<string> task = async.Result.Content.ReadAsStringAsync();
      task.Wait();
      string result = task.Result;
      return true;
    }
  }
}
