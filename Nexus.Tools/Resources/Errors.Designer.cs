﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nexus.Tools.Validations.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Errors {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Errors() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Nexus.Tools.Validations.Resources.Errors", typeof(Errors).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field should this marked as true..
        /// </summary>
        public static string BooleanValidation {
            get {
                return ResourceManager.GetString("BooleanValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field does not contain a valid CNPJ..
        /// </summary>
        public static string CnpjValidation {
            get {
                return ResourceManager.GetString("CnpjValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field must contain a value equal to &apos;{0}&apos;..
        /// </summary>
        public static string CompareValidation {
            get {
                return ResourceManager.GetString("CompareValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field does not contain a valid CPF..
        /// </summary>
        public static string ContainsValidation {
            get {
                return ResourceManager.GetString("ContainsValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field does not contain a valid CPF or CNPJ..
        /// </summary>
        public static string CpfOrCnpjValidation {
            get {
                return ResourceManager.GetString("CpfOrCnpjValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field does not contain a valid CPF..
        /// </summary>
        public static string CpfValidation {
            get {
                return ResourceManager.GetString("CpfValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value of this field does not match a valid email..
        /// </summary>
        public static string EmailValidation {
            get {
                return ResourceManager.GetString("EmailValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        public static string MinLength {
            get {
                return ResourceManager.GetString("MinLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The difference between the current date and the chosen date must be at least {0} years..
        /// </summary>
        public static string MinYearsLestedsValidation {
            get {
                return ResourceManager.GetString("MinYearsLestedsValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Validations.
        /// </summary>
        public static string Name {
            get {
                return ResourceManager.GetString("Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field does not contain one Name..
        /// </summary>
        public static string NameValidation {
            get {
                return ResourceManager.GetString("NameValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A password must contain a number, a lowercase letter, a capital letter and a special character..
        /// </summary>
        public static string PasswordValidation {
            get {
                return ResourceManager.GetString("PasswordValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field must be a valid phone number..
        /// </summary>
        public static string PhoneValidation {
            get {
                return ResourceManager.GetString("PhoneValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field is required..
        /// </summary>
        public static string RequiredValidation {
            get {
                return ResourceManager.GetString("RequiredValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The string must contain at least &apos;{1}&apos; characters..
        /// </summary>
        public static string SmallStringLengthValidation {
            get {
                return ResourceManager.GetString("SmallStringLengthValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The string should not contain more than &apos;{0}&apos; characters..
        /// </summary>
        public static string StringLengthValidation {
            get {
                return ResourceManager.GetString("StringLengthValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This value is not and a time use the format: 00:00:00.
        /// </summary>
        public static string TimeSpanValidation {
            get {
                return ResourceManager.GetString("TimeSpanValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is already a registration using this value..
        /// </summary>
        public static string UniqueInDatabaseValidation {
            get {
                return ResourceManager.GetString("UniqueInDatabaseValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        public static string UrlValidation {
            get {
                return ResourceManager.GetString("UrlValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;{0}&apos; field is not a valid ZIP Code..
        /// </summary>
        public static string ZipCodeValidation {
            get {
                return ResourceManager.GetString("ZipCodeValidation", resourceCulture);
            }
        }
    }
}
