using Nexus.Tools.Validations.Attributes.Base;
using Nexus.Tools.Validations.Resources;
using System;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Attribute for field validation containing CPF or CNPJ.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class CpfOrCnpjAttribute : ValidationAttribute
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public CpfOrCnpjAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Errors.CpfOrCnpjValidation);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string? str = (value is not string vStr) ? value.ToString() : vStr;
            str ??= string.Empty;

            if (CPFOnly)
            {
                if (ErrorMessageResourceName != null &&
                    ErrorMessageResourceType != null &&
                    ErrorMessageResourceName == nameof(Errors.CpfOrCnpjValidation) &&
                    ErrorMessageResourceType.FullName == typeof(Errors).FullName)
                    ErrorMessageResourceName = nameof(Errors.CpfValidation);
                return IsCpf(str);
            }

            if (CNPJOnly)
            {
                if (ErrorMessageResourceName != null &&
                    ErrorMessageResourceType != null && ErrorMessageResourceName == nameof(Errors.CpfOrCnpjValidation) &&
                    ErrorMessageResourceType.FullName == typeof(Errors).FullName)
                    ErrorMessageResourceName = nameof(Errors.CnpjValidation);
                return IsCnpj(str);
            }
            return IsCpf(str) || IsCnpj(str);
        }

        /// <summary>
        /// Determines that validation accepted only CPF.
        /// </summary>
        public bool CPFOnly
        {
            get => _cpfOnly; set
            {
                _cpfOnly = value;
                if (_cpfOnly && _cnpjOnly)
                    _cnpjOnly = false;
            }
        }
        private bool _cpfOnly;
        /// <summary>
        /// Determines that validation accepted only CPJ.
        /// </summary>
        public bool CNPJOnly
        {
            get => _cnpjOnly; set
            {
                _cnpjOnly = value;

                if (_cnpjOnly && _cpfOnly)
                    _cpfOnly = false;

            }
        }
        private bool _cnpjOnly;
        private static bool IsCpf(string cpf)
        {
            int[] numArray1 = new int[9]
            {
        10,
        9,
        8,
        7,
        6,
        5,
        4,
        3,
        2
            };
            int[] numArray2 = new int[10]
            {
        11,
        10,
        9,
        8,
        7,
        6,
        5,
        4,
        3,
        2
            };
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            for (int index = 0; index < 10; ++index)
            {
                if (index.ToString().PadLeft(11, char.Parse(index.ToString())) == cpf)
                    return false;
            }
            string str1 = cpf[..9];
            int num1 = 0;
            char ch;
            for (int index = 0; index < 9; ++index)
            {
                int num2 = num1;
                ch = str1[index];
                int num3 = int.Parse(ch.ToString()) * numArray1[index];
                num1 = num2 + num3;
            }
            int num4 = num1 % 11;
            string str2 = (num4 >= 2 ? 11 - num4 : 0).ToString();
            string str3 = str1 + str2;
            int num5 = 0;
            for (int index = 0; index < 10; ++index)
            {
                int num6 = num5;
                ch = str3[index];
                int num7 = int.Parse(ch.ToString()) * numArray2[index];
                num5 = num6 + num7;
            }
            int num8 = num5 % 11;
            int num9 = num8 >= 2 ? 11 - num8 : 0;
            string str4 = str2 + num9.ToString();
            return cpf.EndsWith(str4);
        }

        private static bool IsCnpj(string cnpj)
        {
            int[] numArray1 = new int[12]
            {
        5,
        4,
        3,
        2,
        9,
        8,
        7,
        6,
        5,
        4,
        3,
        2
            };
            int[] numArray2 = new int[13]
            {
        6,
        5,
        4,
        3,
        2,
        9,
        8,
        7,
        6,
        5,
        4,
        3,
        2
            };
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            string str1 = cnpj[..12];
            int num1 = 0;
            char ch;
            for (int index = 0; index < 12; ++index)
            {
                int num2 = num1;
                ch = str1[index];
                int num3 = int.Parse(ch.ToString()) * numArray1[index];
                num1 = num2 + num3;
            }
            int num4 = num1 % 11;
            string str2 = (num4 >= 2 ? 11 - num4 : 0).ToString();
            string str3 = str1 + str2;
            int num5 = 0;
            for (int index = 0; index < 13; ++index)
            {
                int num6 = num5;
                ch = str3[index];
                int num7 = int.Parse(ch.ToString()) * numArray2[index];
                num5 = num6 + num7;
            }
            int num8 = num5 % 11;
            int num9 = num8 >= 2 ? 11 - num8 : 0;
            string str4 = str2 + num9.ToString();
            return cnpj.EndsWith(str4);
        }
    }
}
