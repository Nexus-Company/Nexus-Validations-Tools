using Microsoft.AspNetCore.Http;
using Nexus.Tools.Validations.Middlewares.Authentication.Attributes;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Middlewares.Authentication
{
    /// <summary>
    /// Asp.Net Core Middleware responsible for defile methods that validate client authentication on the server.
    /// </summary>
    public class AuthenticationMidddleware : BaseMiddleware
    {
        private readonly RequestDelegate next;
        private readonly Func<HttpContext, Task<AuthenticationResult>> validFunc;

        /// <summary>
        /// Start this middleware
        /// </summary>
        /// <param name="next">Next method delegate</param>
        /// <param name="validFunc">Validation method delegate</param>
        public AuthenticationMidddleware(
          RequestDelegate next,
          Func<HttpContext, Task<AuthenticationResult>> validFunc)
        {
            this.next = next;
            this.validFunc = validFunc;
        }

        /// <summary>
        /// Invoke this middleware
        /// </summary>
        /// <param name="ctx">HttpContext</param>
        /// <returns>Task for validation middleware</returns>
        public async Task InvokeAsync(HttpContext ctx)
        {
            RequireAuthenticationAttribute? authAttribute = null;
            AllowAnonymousAttribute? allowAttribute = null;

            try
            {
                authAttribute = TryGetAttribute<RequireAuthenticationAttribute>(ctx, true, true) ?? new RequireAuthenticationAttribute();
                allowAttribute = TryGetAttribute<AllowAnonymousAttribute>(ctx, true, false);
            }
            catch (Exception)
            {
                await next(ctx);
            }

            if (authAttribute != null && allowAttribute == null)
            {
                AuthenticationResult validAuthentication = await validFunc(ctx);

                bool isValid = validAuthentication.IsValidLogin;
                bool confirmedAccount = validAuthentication.ConfirmedAccount;
                bool minLevelReached = (authAttribute.MinAuthenticationLevel ?? 0) <= (validAuthentication.AuthenticationLevel ?? 1);

                if (!isValid /* Valid if login is valid (true) or not (false).*/||
                    !((authAttribute.RequireAccountValidation && confirmedAccount) || !authAttribute.RequireAccountValidation) /* If require accounts validation.*/ ||
                    !minLevelReached /* Valided that the authentication level has been reached.*/)
                {
                    await ReturnObjectOrView(ctx,
                        !minLevelReached ? HttpStatusCode.Forbidden : HttpStatusCode.Unauthorized,
                        authAttribute.ShowView);
                    return;
                }
            }

            await next(ctx);
        }

        /// <summary>
        /// Result for authentication validation 
        /// </summary>
        public class AuthenticationResult
        {
            /// <summary>
            /// Indicates whether the authentication and valid.
            /// </summary>
            public bool IsValidLogin { get; set; }

            /// <summary>
            /// Indicates whether the account for the login has been confirmed using additional means.
            /// </summary>
            public bool ConfirmedAccount { get; set; }

            /// <summary>
            /// Min Required Client Authentication Level
            /// </summary>
            public uint? AuthenticationLevel { get; set; }

            /// <summary>
            /// Constructor for validation 
            /// </summary>
            /// <param name="isValidLogin"></param>
            /// <param name="confirmedAccount"></param>

            public AuthenticationResult(bool isValidLogin, bool confirmedAccount)
            {
                IsValidLogin = isValidLogin;
                ConfirmedAccount = confirmedAccount;
            }

            /// <summary>
            /// Constructor for validation result 
            /// </summary>
            /// <param name="isValidLogin">confirm if is valid login</param>
            /// <param name="confirmedAccount">Confirm if account is confirmed</param>
            /// <param name="authenticationLevel">Min Required authentication level</param>
            public AuthenticationResult(bool isValidLogin, bool confirmedAccount, uint authenticationLevel) : this(isValidLogin, confirmedAccount)
            {
                AuthenticationLevel = authenticationLevel;
            }
        }
    }
}
