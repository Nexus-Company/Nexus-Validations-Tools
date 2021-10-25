using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Nexus.Tools.Validations.Attributes;
using System;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Middlewares.Authentication
{
    /// <summary>
    /// Asp.Net Core Middleware responsible for defile methods that validate client authentication on the server.
    /// </summary>
    public class AuthenticationMidddleware
    {
        private readonly RequestDelegate _next;
        private readonly Func<HttpContext, Task<AuthenticationResult>> _validFunc;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="validFunc"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="urlEncoder"></param>
        public AuthenticationMidddleware(
          RequestDelegate next,
          Func<HttpContext, Task<AuthenticationResult>> validFunc,
          ILoggerFactory loggerFactory,
          UrlEncoder urlEncoder)
        {
            _next = next;
            _validFunc = validFunc;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            RequireAuthenticationAttribute authAttribute = TryGetAttribute<RequireAuthenticationAttribute>(httpContext, false) ?? TryGetAttribute<RequireAuthenticationAttribute>(httpContext, true);
            AllowAnonymousAttribute attribute = TryGetAttribute<AllowAnonymousAttribute>(httpContext, false);
           
            if (authAttribute == null || attribute != null)
            {
                await _next(httpContext);
            }
            else
            {
                bool flag1 = attribute != null;
                bool flag2 = false;

                if (!flag1)
                {
                    AuthenticationResult validAuthentication = await _validFunc(httpContext);
                    flag1 = validAuthentication.IsValidLogin;
                    flag2 = validAuthentication.ConfirmedAccount;
                }

                if (!flag1 || (authAttribute.RequireValidEmail && !flag2))
                {
                    await ReturnView(httpContext);
                    authAttribute = null;
                }
                else
                {
                    await _next(httpContext);
                }
            }
        }
#nullable enable
        private static T? TryGetAttribute<T>(HttpContext httpContext, bool controller)
        {
            ControllerActionDescriptor metadata = httpContext.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>();
            object obj = null;
            return metadata == null ? (T)obj : (T)(!controller ? metadata.MethodInfo.GetCustomAttribute(typeof(T)) : (object)metadata.ControllerTypeInfo.GetCustomAttribute(typeof(T)));
        }
#nullable disable
        private static async Task ReturnView(HttpContext context) => context.Response.StatusCode = 401;

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
            /// Constructor for validation 
            /// </summary>
            /// <param name="isValidLogin"></param>
            /// <param name="confirmedAccount"></param>

            public AuthenticationResult(bool isValidLogin, bool confirmedAccount)
            {
                IsValidLogin = isValidLogin;
                ConfirmedAccount = confirmedAccount;
            }
        }
    }
}
