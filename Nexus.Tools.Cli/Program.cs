using Nexus.Tools.Validations.Test;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading;

namespace Nexus.Tools.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid = false;
            TestAllAttributes test = new()
            {
                Birthday = DateTime.Now - TimeSpan.FromDays(365 * 19),
                Password = "Am4@0309",
                Email = "ass@gmail.com",
                Phone = "(61) 9 9260-6441",
                ComparePassword = "Am4@0309",
                CPF = "07654042140",
                CNPJ = "",
                MinLength = "*******",
                MaxLength = "*********",
                Name = "Juan Douglas"
            };
            ValidationContext validationContext = new(test, null, new Dictionary<object, object>());
            Thread.CurrentThread.CurrentUICulture = new("pt-br");

            //ICollection<ValidationResult> result = Array.Empty<ValidationResult>();
            //isValid = Validator.TryValidateObject(test, validationContext, result, true);
            Validator.ValidateObject(test, validationContext);
            Console.ReadLine();
        }
    }
}
