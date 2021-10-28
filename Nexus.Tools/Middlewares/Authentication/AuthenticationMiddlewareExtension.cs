using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Middlewares.Authentication
{
    /// <summary>
    /// Extensions for authentication middleware 
    /// </summary>
    public static class AuthenticationMiddlewareExtension
    {
        /// <summary>
        /// Starts Nexus Authentication Middleware with an asynchronous delegate method.
        /// </summary>
        /// <param name="builder">IApplicationBuilder target of Middleware.</param>
        /// <param name="validFunc">Asynchronous authentication validation function.</param>
        /// <returns>IAplicationBuilder with Middleware already added.</returns>
        public static IApplicationBuilder UseAuthentication(
          this IApplicationBuilder builder,
          Func<HttpContext, Task<AuthenticationMidddleware.AuthenticationResult>> validFunc)
        {
            return builder.UseMiddleware<AuthenticationMidddleware>(validFunc);
        }

        /// <summary>
        /// Starts Nexus Authentication Middleware with a synchronous delegate method.
        /// </summary>
        /// <param name="builder">IApplicationBuilder target of Middleware.</param>
        /// <param name="validFunc">Delegate of the authentication validation method.</param>
        /// <returns>IAplicationBuilder with Middleware already added.</returns>
        public static IApplicationBuilder UseAuthentication(
          this IApplicationBuilder builder,
          Func<HttpContext, AuthenticationMidddleware.AuthenticationResult> validFunc)
        {
            Func<HttpContext, Task<AuthenticationMidddleware.AuthenticationResult>> validFuncAsync = delegate (HttpContext s)
             {
                 return Task.Run(() => { return validFunc.Invoke(s); });
             };

            return builder.UseMiddleware<AuthenticationMidddleware>(validFuncAsync);
        }
        /// <summary>
        /// Start middleware for simple true, false validation result.
        /// </summary>
        /// <param name="builder">IApplicationBuilder target of Middleware</param>
        /// <param name="validFunc">Validation delegate method</param>
        /// <returns>IAplicationBuilder with Middleware already added.</returns>
        public static IApplicationBuilder UseAuthentication(
          this IApplicationBuilder builder,
          Func<HttpContext, bool> validFunc)
        {
            Func<HttpContext, AuthenticationMidddleware.AuthenticationResult> func = delegate (HttpContext ctx) {
                bool result = validFunc.Invoke(ctx);
                return new AuthenticationMidddleware.AuthenticationResult(result, result);
            };

            return builder.UseAuthentication(func);
        }
    }
}
