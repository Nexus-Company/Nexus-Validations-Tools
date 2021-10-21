using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Middlewares
{
    /// <summary>
    /// Extensions for 
    /// </summary>
    public static class AuthenticationMiddlewareExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="validFunc"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAuthentication(
          this IApplicationBuilder builder,
          Func<HttpContext, Task<AuthenticationMidddleware.ValidAuthentication>> validFunc)
        {
            return builder.UseMiddleware<AuthenticationMidddleware>(validFunc);
        }
    }
}
