using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Middlewares
{
    public abstract class BaseMiddleware
    {
#nullable enable
        protected internal static T? TryGetAttribute<T>(HttpContext httpContext, bool controller)
        {
            ControllerActionDescriptor metadata = httpContext.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>();
            object? obj = null;
            return metadata == null ? (T?)obj : (T?)(!controller ? metadata.MethodInfo.GetCustomAttribute(typeof(T)) : (object?)metadata.ControllerTypeInfo.GetCustomAttribute(typeof(T)));
        }


        protected internal static async Task ReturnObjectOrView(HttpContext context, HttpStatusCode statusCode, bool showView, string? viewName, object? obj)
        {

        }

        protected internal static async Task ReturnView(HttpContext context, HttpStatusCode statusCode, string viewName, object? obj)
        {

        }

        protected internal static async Task ReturnObject(HttpContext context, HttpStatusCode statusCode, object? obj)
        {
            context.Response.StatusCode = (int)statusCode;
            if (obj != null)
            {
                string str = await Task.Run(() => JsonConvert.SerializeObject(obj));
#warning Especif get request encoding for working
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                context.Response.Body = new MemoryStream(bytes);
            }
        }
#nullable disable
    }
}
