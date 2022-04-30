using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Middlewares.Attacks
{
    internal class BruteForceMiddleware : BaseMiddleware
    {
        public BruteForceMiddleware(RequestDelegate next) : base(next)
        {
        }

        public override async Task InvokeAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
