using System;

namespace Nexus.Tools.Validations.Middlewares.Authentication.Attributes
{
    /// <summary>
    /// Informs Authentication Middleware that the class or method requires autenticated user.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public sealed class RequireAuthenticationAttribute : Attribute
    {/// <summary>
     ///  Informs Authentication Middleware that the class or method requires a validated account.
     /// </summary>
        public bool RequireAccountValidation { get; set; }

        public bool ShowView { get; set; }
    }
}
