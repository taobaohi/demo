using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

/// <summary>
/// 参考:https://thecodebuzz.com/best-practices-for-handling-exception-in-net-core-2-1/
/// https://thecodebuzz.com/filters-in-net-core-best-practices/
/// </summary>
namespace servicedemo.middleware
{
    using servicedemo.models.dto.comm;

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ExceptionMiddleware(RequestDelegate next,ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
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
            object requestData = null;
            if (context.Request.Method=="POST" && context.Request.Body.Length>0)
            {
                using (var reader = new System.IO.StreamReader(context.Request.Body, System.Text.Encoding.UTF8))
                {
                    context.Request.Body.Position = 0;
                    requestData = reader.ReadToEnd();
                }
            }
            else if(context.Request.Method == "GET")
            {
                requestData = string.Join("&",context.Request.Query.Select(q => $"{q.Key}={q.Value}"));
            }

            return context.Response.WriteAsync(
                new ErrorMessage
                {
                    code = context.Response.StatusCode,
                    requestMethod = context.Request.Method,
                    requestUrl = $"{context.Request.Scheme}://{context.Request.Host}/{context.Request.Path}/",
                    requestData = requestData,
#if DEBUG
                    msg = $"{exception.Message}:{exception.StackTrace}"
#else
                    //msg= "Something went wrong !Internal Server Error"
                    msg = $"{exception.Message}:{exception.StackTrace}"
#endif
                }.ToString()
            ); ;
        }

    }
}
