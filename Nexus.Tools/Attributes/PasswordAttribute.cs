﻿using Nexus.Tools.Validations.Resources;
using System.ComponentModel.DataAnnotations;

namespace Nexus.Tools.Validations.Attributes
{
    public class PasswordAttribute : ValidationAttribute
    {
        public PasswordAttribute()
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "PasswordValidation";
        }
        public static string[] Require
        {
            get => new string[] { "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "abcdefghijkllmnopqrstuvwxyz",
            "1234567890",
            @"!@#$%¨&*()_+{`^}:?><,./\-§=ºª" };
        }

#pragma warning disable CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.
        public override bool IsValid(object? obj)
#pragma warning restore CS8632 // A anotação para tipos de referência anuláveis deve ser usada apenas em código em um contexto de anotações '#nullable'.
        {
            obj ??= "";

            string str = obj.ToString();
            for (int i = 0; i < Require.Length; i++)
            {
                bool contains = false;
                foreach (char letter in Require[i])
                {
                    if (str.Contains(letter))
                    {
                        contains = true;
                        break;
                    }
                }

                if (!contains)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
