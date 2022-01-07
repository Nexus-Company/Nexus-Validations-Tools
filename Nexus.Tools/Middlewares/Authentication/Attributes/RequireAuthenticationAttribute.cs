using System;

namespace Nexus.Tools.Validations.Middlewares.Authentication.Attributes
{
    /// <summary>
    /// Informs <see cref="AuthenticationMidddleware"/> that the class or method requires autenticated user.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public sealed class RequireAuthenticationAttribute : Attribute
    {
        /// <summary>
        ///  Informs Authentication Middleware that the class or method requires a validated account.
        /// </summary>
        public bool RequireAccountValidation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowView { get; set; }

        /// <summary>
        ///  Min required AuthenticationLevel
        /// </summary>
        public uint? MinAuthenticationLevel { get; set; }
    }
}
