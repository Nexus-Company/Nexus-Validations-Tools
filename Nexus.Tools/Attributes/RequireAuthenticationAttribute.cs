using System;

namespace Nexus.Tools.Validations.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public sealed class RequireAuthenticationAttribute : Attribute
    {
        public bool RequireValidEmail { get; set; }

        public bool ShowView { get; set; }
    }
}
