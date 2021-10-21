using Nexus.Tools.Validations.Attributes;
using System;

namespace Nexus.Tools.Validations.Test
{
    public class TestAllAttributes
    {
        [MinYearsLesteds(18)]
        public DateTime Birthday { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Password]
        public string Password { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Compare("Password")]
        public string ComparePassword { get; set; }
        [CpfOrCnpj(CPFOnly = true)]
        public string CPF { get; set; }
        [CpfOrCnpj(CNPJOnly = true)]
        public string CNPJ { get; set; }
        [StringLength(15,MinimumLength = 8)]
        public string MinLength { get; set; }
        [StringLength(8)]
        public string MaxLength { get; set; }
        [Name]
        public string Name { get; set; }
    }
}