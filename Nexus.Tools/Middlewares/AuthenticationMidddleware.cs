using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Nexus.Tools.Validations.Attributes;
using System;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


#nullable enable
namespace Nexus.Tools.Validations.Middlewares
{
    public class AuthenticationMidddleware
    {
        private readonly
#nullable disable
    RequestDelegate _next;
        private readonly Func<HttpContext, Task<AuthenticationMidddleware.ValidAuthentication>> _validFunc;

        public AuthenticationMidddleware(
          RequestDelegate next,
          Func<HttpContext, Task<AuthenticationMidddleware.ValidAuthentication>> validFunc,
          ILoggerFactory loggerFactory,
          UrlEncoder urlEncoder)
        {
            _next = next;
            _validFunc = validFunc;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            RequireAuthenticationAttribute authAttribute = AuthenticationMidddleware.TryGetAttribute<RequireAuthenticationAttribute>(httpContext, false) ?? AuthenticationMidddleware.TryGetAttribute<RequireAuthenticationAttribute>(httpContext, true);
            AllowAnonymousAttribute attribute = AuthenticationMidddleware.TryGetAttribute<AllowAnonymousAttribute>(httpContext, false);
            if (authAttribute == null || attribute != null)
            {
                await _next(httpContext);
                authAttribute = (RequireAuthenticationAttribute)null;
            }
            else
            {
                bool flag1 = attribute != null;
                bool flag2 = false;
                if (!flag1)
                {
                    ValidAuthentication validAuthentication = await _validFunc(httpContext);
                    flag1 = validAuthentication.IsValidLogin;
                    flag2 = validAuthentication.ConfirmedAccount;
                }
                if (!flag1 || authAttribute.RequireValidEmail && !flag2)
                {
                    await AuthenticationMidddleware.ReturnView(httpContext);
                    authAttribute = (RequireAuthenticationAttribute)null;
                }
                else
                {
                    await _next(httpContext);
                    authAttribute = (RequireAuthenticationAttribute)null;
                }
            }
        }

        private static
#nullable enable
    T? TryGetAttribute<T>(HttpContext httpContext, bool controller)
        {
            ControllerActionDescriptor metadata = httpContext.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>();
            object obj = (object)null;
            return metadata == null ? (T)obj : (T)(!controller ? (object)metadata.MethodInfo.GetCustomAttribute(typeof(T)) : (object)metadata.ControllerTypeInfo.GetCustomAttribute(typeof(T)));
        }

        private static async
#nullable disable
    Task ReturnView(HttpContext context) => context.Response.StatusCode = 401;

        public class ValidAuthentication
        {
            public bool IsValidLogin { get; set; }

            public bool ConfirmedAccount { get; set; }

            public ValidAuthentication(bool isValidLogin, bool confirmedAccount)
            {
                IsValidLogin = isValidLogin;
                ConfirmedAccount = confirmedAccount;
            }
        }
    }
}
