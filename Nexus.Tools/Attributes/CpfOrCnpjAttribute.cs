
// Type: Nexus.Tools.Validations.Attributes.CpfOrCnpjAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Nexus.Tools.Validations.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class CpfOrCnpjAttribute : ValidationAttribute
    {
        public CpfOrCnpjAttribute()
        {
            ErrorMessage = (string)null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "CpfOrCnpjValidation";
        }

        public override bool IsValid(object value)
        {
            string empty = string.Empty;
            if (value == null)
                return false;
            string str = !(value is string) ? value.ToString() : value as string;
            if (CPFOnly)
            {
                if (ErrorMessageResourceName != null && ErrorMessageResourceType != (Type)null && ErrorMessageResourceName == "CpfOrCnpjValidation" && ErrorMessageResourceType.FullName == typeof(Errors).FullName)
                    ErrorMessageResourceName = "CpfValidation";
                return CpfOrCnpjAttribute.IsCpf(str);
            }
            if (CNPJOnly)
            {
                if (ErrorMessageResourceName != null && ErrorMessageResourceType != (Type)null && ErrorMessageResourceName == "CpfOrCnpjValidation" && ErrorMessageResourceType.FullName == typeof(Errors).FullName)
                    ErrorMessageResourceName = "CnpjValidation";
                return CpfOrCnpjAttribute.IsCnpj(str);
            }
            return CpfOrCnpjAttribute.IsCpf(str) || CpfOrCnpjAttribute.IsCnpj(str);
        }

        public bool CPFOnly { get; set; }

        public bool CNPJOnly { get; set; }

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
            string str1 = cpf.Substring(0, 9);
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
            string str1 = cnpj.Substring(0, 12);
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
