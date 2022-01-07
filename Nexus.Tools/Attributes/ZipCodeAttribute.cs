using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ZipCodeAttribute : ValidationAttribute
    {
        public ZipCodeAttribute()
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "ZipCodeValidation";
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

            return true;
        }
    }
}
