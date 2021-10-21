// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Middlewares.AuthenticationMiddlewareExtension
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Middlewares
{
  public static class AuthenticationMiddlewareExtension
  {
    public static IApplicationBuilder UseAuthentication(
      this IApplicationBuilder builder,
      Func<HttpContext, Task<AuthenticationMidddleware.ValidAuthentication>> validFunc)
    {
      return builder.UseMiddleware<AuthenticationMidddleware>((object) validFunc);
    }
  }
}
