using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace servicedemo.middleware
{
    using servicedemo.models.dto.wapper;

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _logger = new LoggerFactory().AddConsole()
                .CreateLogger("GlobalException");
            //Lets create new console logger overriding any default logging configuration 
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex.ToString()}");
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(
                new ResponseT<string>
                {
                    code = enums.CodeEnum.Error, //context.Response.StatusCode
#if DEBUG
                    msg = exception.ToString()
#else
                    msg= "Something went wrong !Internal Server Error"
#endif
                }.ToString()
            );
        }
    }
}
