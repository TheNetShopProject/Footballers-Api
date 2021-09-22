using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Middleware
{
    public class RequestTimeHandlingMiddleware :IMiddleware
    {
        private readonly ILogger<RequestTimeHandlingMiddleware> _logger;
        private readonly Stopwatch _stopwatch;

        public RequestTimeHandlingMiddleware(ILogger<RequestTimeHandlingMiddleware> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();

           var requestTime= _stopwatch.ElapsedMilliseconds;
           if (requestTime / 1000 > 4)
           {
               string message = $"Request [{context.Request.Method}] at {context.Request.Path} took {requestTime} ms";
               _logger.LogWarning(message);
           }

        }
    }
}