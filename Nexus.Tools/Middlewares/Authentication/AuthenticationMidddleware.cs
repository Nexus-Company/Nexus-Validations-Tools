using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nexus.Tools.Validations.Middlewares.Authentication.Attributes;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Middlewares.Authentication;

/// <summary>
/// Asp.Net Core Middleware responsible for defile methods that validate client authentication on the server.
/// </summary>
/// <remarks>
/// Start this middleware
/// </remarks>
/// <param name="next">Next method delegate</param>
/// <param name="validFunc">Validation method delegate</param>
internal partial class AuthenticationMidddleware(
  RequestDelegate next,
  Func<HttpContext, Task<AuthenticationResult>> validFunc) : BaseMiddleware(next)
{
    private readonly Func<HttpContext, Task<AuthenticationResult>> validFunc = validFunc;

    /// <summary>
    /// Invoke this middleware
    /// </summary>
    /// <param name="ctx">HttpContext</param>
    /// <returns>Task for validation middleware</returns>
    public override async Task InvokeAsync(HttpContext ctx)
    {
        RequireAuthenticationAttribute? authAttribute = null;
        AllowAnonymousAttribute? allowAttribute = null;

        try
        {
            (authAttribute, allowAttribute) = GetAttributes(ctx);
        }
        catch (Exception)
        {
            await _next(ctx);
        }

        if (authAttribute != null && allowAttribute == null)
        {
            AuthenticationResult validAuthentication = await validFunc(ctx);

            if (AuthenticationResultValid(validAuthentication, authAttribute, out bool minLevelReached))
            {
                await ReturnObjectOrView(ctx,
                   !minLevelReached ? HttpStatusCode.Forbidden : HttpStatusCode.Unauthorized,
                   authAttribute.ShowView);
                return;
            }
        }

        await _next(ctx);
    }

    internal static Tuple<RequireAuthenticationAttribute?, AllowAnonymousAttribute?> GetAttributes(HttpContext ctx)
        => Tuple.Create(TryGetAttribute<RequireAuthenticationAttribute>(ctx, true, true),
                        TryGetAttribute<AllowAnonymousAttribute>(ctx, true, false));

    internal static bool AuthenticationResultValid(AuthenticationResult validAuthentication, RequireAuthenticationAttribute authAttribute, out bool minLevelReached)
    {
        bool
            isValid = validAuthentication.IsValidLogin,
            confirmedAccount = validAuthentication.ConfirmedAccount;
        minLevelReached = authAttribute.MinAuthenticationLevel <= validAuthentication.AuthenticationLevel;

        string? scope = authAttribute.Scope;

        if (minLevelReached)
        {
            if (!string.IsNullOrWhiteSpace(scope))
            {
                bool exists = false;
                foreach (var scp in validAuthentication.Scopes)
                {
                    if (scope.Equals(scp, StringComparison.InvariantCultureIgnoreCase))
                    {
                        exists = true;
                        break;
                    }
                }

                minLevelReached = exists;
            }
        }

        /*
         * This snippet returns true (i.e., valid authentication) when all the conditions listed below are met. 
         * If any validation returns true, it means it has not been fulfilled. 
         * Therefore, all validations are negated.
         */
        return !(!isValid /* Valid if login is valid (true) or not (false).*/||
            authAttribute.RequireAccountValidation && !confirmedAccount || /* If require accounts validation.*/
            !minLevelReached || /* Valided that the authentication level has been reached.*/
            authAttribute.RequiresToBeOwner && !validAuthentication.IsOwner);
    }
}

/// <summary>
/// Asp.Net Core Middleware responsible for defile methods that validate client authentication on the server. 
/// </summary>
/// <typeparam name="TContext">Dabase context type.</typeparam>
internal class AuthenticationMidddleware<TContext>
    where TContext : DbContext
{
    private readonly Func<HttpContext, TContext, Task<AuthenticationResult>> _validFunc;
    private readonly RequestDelegate _next;

    /// <summary>
    /// Start this middleware
    /// </summary>
    /// <param name="next">Next method delegate</param>
    /// <param name="validFunc">Validation method delegate</param>
    public AuthenticationMidddleware(
        RequestDelegate next,
        Func<HttpContext, TContext, Task<AuthenticationResult>> validFunc)
    {
        _validFunc = validFunc;
        _next = next;
    }

    /// <summary>
    /// Invoke this middleware
    /// </summary>
    /// <param name="ctx">Http request and response context</param>
    /// <param name="db">Database context</param>
    /// <returns>Task for validation middleware</returns>
    public async Task InvokeAsync(HttpContext ctx, TContext db)
    {
        RequireAuthenticationAttribute? authAttribute = null;
        AllowAnonymousAttribute? allowAttribute = null;

        try
        {
            (authAttribute, allowAttribute) = AuthenticationMidddleware.GetAttributes(ctx);
        }
        catch (Exception)
        {
            await _next(ctx);
        }

        if (authAttribute != null && allowAttribute == null)
        {
            AuthenticationResult validAuthentication = await _validFunc(ctx, db);

            if (AuthenticationMidddleware.AuthenticationResultValid(validAuthentication, authAttribute, out bool minLevelReached))
            {
                await BaseMiddleware.ReturnObjectOrView(ctx,
                   !minLevelReached ? HttpStatusCode.Forbidden : HttpStatusCode.Unauthorized,
                   authAttribute.ShowView);
                return;
            }
        }

        await _next(ctx);
    }
}

/// <summary>
/// Asp.Net Core Middleware responsible for defile methods that validate client authentication on the server. 
/// </summary>
/// <typeparam name="TContext">Dabase context type.</typeparam>
/// <typeparam name="TService">One aditional Service for validation.</typeparam>
internal class AuthenticationMidddleware<TContext, TService>
     where TContext : DbContext
{
    private readonly Func<HttpContext, TContext, TService, Task<AuthenticationResult>> _validFunc;
    private readonly RequestDelegate _next;

    /// <summary>
    /// Start this middleware
    /// </summary>
    /// <param name="next">Next method delegate</param>
    /// <param name="validFunc">Validation method delegate</param>
    public AuthenticationMidddleware(
        RequestDelegate next,
        Func<HttpContext, TContext, TService, Task<AuthenticationResult>> validFunc)
    {
        _validFunc = validFunc;
        _next = next;
    }

    /// <summary>
    /// Invoke this middleware
    /// </summary>
    /// <param name="ctx">Http request and response context</param>
    /// <param name="db">Database context</param>
    /// <returns>Task for validation middleware</returns>
    public async Task InvokeAsync(HttpContext ctx, TContext db, TService service)
    {
        RequireAuthenticationAttribute? authAttribute = null;
        AllowAnonymousAttribute? allowAttribute = null;

        try
        {
            (authAttribute, allowAttribute) = AuthenticationMidddleware.GetAttributes(ctx);
        }
        catch (Exception)
        {
            await _next(ctx);
        }

        if (authAttribute != null && allowAttribute == null)
        {
            AuthenticationResult validAuthentication = await _validFunc(ctx, db, service);

            if (!AuthenticationMidddleware.AuthenticationResultValid(validAuthentication, authAttribute, out bool minLevelReached))
            {
                await BaseMiddleware.ReturnObjectOrView(ctx,
                   !minLevelReached ? HttpStatusCode.Forbidden : HttpStatusCode.Unauthorized,
                   authAttribute.ShowView);
                return;
            }
        }

        await _next(ctx);
    }
}