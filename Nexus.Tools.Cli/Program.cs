using Nexus.Tools.Validations.Test;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Nexus.Tools.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAllAttributes test = new()
            {
                Birthday = DateTime.Now - TimeSpan.FromDays(365 * 19),
                Password = "Am4@0309",
                Email = "ass@gmail.com",
                Phone = "(61) 99260-6441",
                ComparePassword = "Am4@0309",
                CPF = "07654042140",
                CNPJ = ""
            };
            ValidationContext validationContext = new(test, null, null);
            Thread.CurrentThread.CurrentUICulture = new("pt-br");
            List<ValidationResult> result = new();
            var isValid = Validator.TryValidateObject(test, validationContext, result, true);
            Validator.ValidateObject(test, validationContext);
        }
    }
}
