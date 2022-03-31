using System;

namespace Nexus.Tools.Validations.Middlewares.Attacks.Attributes
{
    /// <summary>
    /// Informs <see cref="AntiXssMiddleware"/> of authentication that this class or method accepts anonymous requests.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class ValidXssAttribute : Attribute
    {
    }
}
