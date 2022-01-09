using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexus.Tools.Validations.Middlewares.Attacks;

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
