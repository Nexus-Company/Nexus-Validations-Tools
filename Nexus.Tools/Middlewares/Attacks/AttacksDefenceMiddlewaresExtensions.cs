using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Middlewares.Attacks
{
    public static class AttacksDefenceMiddlewaresExtensions
    {
        /// <summary>
        /// Active AntiXss middleware
        /// </summary>
        /// <param name="builder">Asp.Net Application Builder</param>
        /// <returns></returns>
        public static IApplicationBuilder UseXssDefense(this IApplicationBuilder builder) =>
            builder.UseMiddleware<AntiXssMiddleware>();

    }
}
