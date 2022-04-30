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
        private readonly Func<HttpContext, Task<AuthenticationResult>> validFunc;

        /// <summary>
        /// Start this middleware
        /// </summary>
        /// <param name="next">Next method delegate</param>
        /// <param name="validFunc">Validation method delegate</param>
        public AuthenticationMidddleware(
          RequestDelegate next,
          Func<HttpContext, Task<AuthenticationResult>> validFunc) : base(next)
        {
            this.validFunc = validFunc;
        }

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
                bool minLevelReached = (authAttribute.MinAuthenticationLevel) <= (validAuthentication.AuthenticationLevel);

                if (!isValid /* Valid if login is valid (true) or not (false).*/||
                    !((authAttribute.RequireAccountValidation && confirmedAccount) || !authAttribute.RequireAccountValidation) || /* If require accounts validation.*/
                    !minLevelReached || /* Valided that the authentication level has been reached.*/
                    (!validAuthentication.IsOwner && authAttribute.RequiresToBeOwner))
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
            public int AuthenticationLevel { get; set; }

            /// <summary>
            /// Defines if this access is of resource owner
            /// </summary>
            public bool IsOwner { get; set; }

            /// <summary>
            /// Constructor for validation 
            /// </summary>
            /// <param name="isValidLogin"></param>
            /// <param name="confirmedAccount"></param>

            public AuthenticationResult(bool isValidLogin, bool confirmedAccount)
            {
                IsValidLogin = isValidLogin;
                IsOwner = true;
                ConfirmedAccount = confirmedAccount;
                AuthenticationLevel = 1;
            }

            /// <summary>
            /// Constructor for validation result 
            /// </summary>
            /// <param name="isValidLogin">confirm if is valid login</param>
            /// <param name="confirmedAccount">Confirm if account is confirmed</param>
            /// <param name="authenticationLevel">Min Required authentication level</param>
            public AuthenticationResult(bool isValidLogin, bool confirmedAccount, int authenticationLevel) : this(isValidLogin, confirmedAccount)
            {
                AuthenticationLevel = authenticationLevel;
            }
        }
    }
}
