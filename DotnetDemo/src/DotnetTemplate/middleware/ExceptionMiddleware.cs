using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// https://thecodebuzz.com/best-practices-for-handling-exception-in-net-core-2-1/

namespace servicedemo.middleware
{
    using servicedemo.models.dto.comm;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

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
                //requestData = DeserializeFromStream(context.Request.Body);
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
                    msg= "Something went wrong !Internal Server Error"
#endif
                }.ToString()
            ); ;
        }

        public static object DeserializeFromStream(Stream stream)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                stream.Position = 0;
                object o = formatter.Deserialize(stream);
                return o;
            }
            catch(Exception ex)
            {
                var aa = ex;
                return null;
            }
        }
            

    }
}
