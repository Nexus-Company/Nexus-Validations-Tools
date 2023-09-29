using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Middlewares.Authentication;

/// <summary>
/// Extensions for authentication middleware 
/// </summary>
public static class AuthenticationMiddlewareExtension
{
    /// <summary>
    /// Starts Nexus Authentication Middleware with an asynchronous delegate method.
    /// In Config(..) put enter after UseRouting and before UseEndpoints.
    /// </summary>
    /// <param name="builder">IApplicationBuilder target of Middleware.</param>
    /// <param name="validFunc">Asynchronous authentication validation function.</param>
    /// <returns>IAplicationBuilder with Middleware already added.</returns>
    public static IApplicationBuilder UseAuthentication(
      this IApplicationBuilder builder,
      Func<HttpContext, Task<AuthenticationResult>> validFunc)
    {
        return builder.UseMiddleware<AuthenticationMidddleware>(validFunc);
    }

    /// <summary>
    /// Starts Nexus Authentication Middleware with an asynchronous delegate method.
    /// In Config(..) put enter after UseRouting and before UseEndpoints.
    /// </summary>
    /// <typeparam name="TContext">Type of database EF context</typeparam>
    /// <param name="builder">IApplicationBuilder target of Middleware.</param>
    /// <param name="validFunc">Asynchronous authentication validation function.</param>
    /// <returns>IAplicationBuilder with Middleware already added.</returns>
    public static IApplicationBuilder UseAuthentication<TContext>(
        this IApplicationBuilder builder,
        Func<HttpContext, TContext, Task<AuthenticationResult>> validFunc)
        where TContext : DbContext
    {
        return builder.UseMiddleware<AuthenticationMidddleware<TContext>>(validFunc);
    }

    /// <summary>
    /// Starts Nexus Authentication Middleware with an asynchronous delegate method.
    /// In Config(..) put enter after UseRouting and before UseEndpoints.
    /// </summary>
    /// <typeparam name="TContext">Type of database EF context</typeparam>
    /// <typeparam name="TService">Type of necessery service validation.</typeparam>
    /// <param name="builder">IApplicationBuilder target of Middleware.</param>
    /// <param name="validFunc">Asynchronous authentication validation function.</param>
    /// <returns>IAplicationBuilder with Middleware already added.</returns>
    public static IApplicationBuilder UseAuthentication<TContext, TService>(
        this IApplicationBuilder builder,
        Func<HttpContext, TContext, TService, Task<AuthenticationResult>> validFunc)
        where TContext : DbContext
    {
        return builder.UseMiddleware<AuthenticationMidddleware<TContext, TService>>(validFunc);
    }

    /// <summary>
    /// Starts Nexus Authentication Middleware with a synchronous delegate method.
    /// In Config(..) put enter after UseRouting and before UseEndpoints.
    /// </summary>
    /// <param name="builder">IApplicationBuilder target of Middleware.</param>
    /// <param name="validFunc">Delegate of the authentication validation method.</param>
    /// <returns>IAplicationBuilder with Middleware already added.</returns>
    public static IApplicationBuilder UseAuthentication(
      this IApplicationBuilder builder,
      Func<HttpContext, AuthenticationResult> validFunc)
    {
        Func<HttpContext, Task<AuthenticationResult>> validFuncAsync = delegate (HttpContext s)
         {
             return Task.Run(() => { return validFunc.Invoke(s); });
         };

        return builder.UseMiddleware<AuthenticationMidddleware>(validFuncAsync);
    }

    /// <summary>
    /// Start middleware for simple true, false validation result.
    /// In Config(..) put enter after UseRouting and before UseEndpoints.
    /// </summary>
    /// <param name="builder">IApplicationBuilder target of Middleware</param>
    /// <param name="validFunc">Validation delegate method</param>
    /// <returns>IAplicationBuilder with Middleware already added.</returns>
    public static IApplicationBuilder UseAuthentication(
      this IApplicationBuilder builder,
      Func<HttpContext, bool> validFunc)
    {
        AuthenticationResult func(HttpContext ctx)
        {
            bool result = validFunc.Invoke(ctx);
            return new AuthenticationResult(result, result);
        }

        return builder.UseAuthentication(func);
    }
}