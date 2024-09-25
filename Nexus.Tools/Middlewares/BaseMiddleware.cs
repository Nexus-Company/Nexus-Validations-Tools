﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Middlewares;

public abstract class BaseMiddleware(RequestDelegate next)
{
    protected internal readonly RequestDelegate _next = next;

    public abstract Task InvokeAsync(HttpContext context);

    protected internal static TAttribute? TryGetAttribute<TAttribute>(HttpContext ctx, bool controller, bool inherit)
    {
        ControllerActionDescriptor? metadata = (ctx.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>())
            ?? throw new Exception($"Cannot get attribute of type: {typeof(TAttribute).Name}");

        if (metadata == null)
            return (TAttribute?)(object?)null;

        object? obj = metadata.MethodInfo.GetCustomAttribute(typeof(TAttribute), inherit);

        if (obj == null && controller)
        {
            obj = metadata.ControllerTypeInfo.GetCustomAttribute(typeof(TAttribute), inherit);
        }

        TAttribute? result = (TAttribute?)obj;
        return result;
    }

    protected internal static async Task ReturnObjectOrView(HttpContext context, HttpStatusCode statusCode, bool showView, string? viewName = null, object? obj = null)
    {
        if (showView)
        {
#warning Implements Return View method
            //await ReturnView(context, statusCode, viewName ?? string.Empty, obj);
            //return;
        }

        await ReturnObject(context, statusCode, showView);
    }

    protected internal static void ReturnView(HttpContext context, HttpStatusCode statusCode, string viewName, object? obj)
    {
        throw new NotImplementedException();
    }

    protected internal static async Task ReturnObject(HttpContext context, HttpStatusCode statusCode, object? obj)
    {
        context.Response.StatusCode = (int)statusCode;
        if (obj != null)
        {
            string str = (obj is string cast) ? cast : string.Empty;

            if (obj != null)
            {
                await Task.Run(() => JsonConvert.SerializeObject(obj));
            }

#warning Especif get request encoding for working
            byte[] bytes = Encoding.Default.GetBytes(str);
            context.Response.Body = new MemoryStream(bytes);
        }
    }
}
