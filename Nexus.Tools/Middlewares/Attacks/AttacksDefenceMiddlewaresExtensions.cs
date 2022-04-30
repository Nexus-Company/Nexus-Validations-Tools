using Microsoft.AspNetCore.Builder;

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

        public static IApplicationBuilder UseBruteForceDefense(this IApplicationBuilder builder) =>
            builder.UseMiddleware<BruteForceMiddleware>();
    }
}
