namespace IceNineMedia.Core.Features.Middleware
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class BlazorRoutingMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value ?? string.Empty;

            // Check if the path matches your Blazor route pattern
            if (path.Equals("/_blazor"))
            {
                // Rewrite the request path to the Blazor host page
                context.Request.Path = "/_Host";
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}