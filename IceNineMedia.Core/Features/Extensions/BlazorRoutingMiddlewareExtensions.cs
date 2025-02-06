namespace IceNineMedia.Core.Features.Extensions
{
    using IceNineMedia.Core.Features.Middleware;
    using Microsoft.AspNetCore.Builder;

    public static class BlazorRoutingMiddlewareExtensions
    {
        public static IApplicationBuilder UseBlazorRouting(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BlazorRoutingMiddleware>();
        }
    }
}