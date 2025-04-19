namespace webapi.Middlewares
{
    public class TimeMiddleware
    {
        readonly RequestDelegate _next;
        public TimeMiddleware(RequestDelegate nextRequest)
        {
            _next = nextRequest;
        }
        public async Task Invoke(HttpContext context)
        {
            await _next(context);
            if (context.Request.Query.Any(p => p.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
            }
        }

    }
    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}
