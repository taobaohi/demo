using Microsoft.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace servicedemo.middleware
{
    public class MyExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;

            //这里可以写一些日志记录的代码
            // context.Result = CreatedAtActionResult("");
            //var aaa = new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("");
            //context.Result = new ContentResult()
            //{
            //    Content = $"捕捉到未处理的异常：{ex.GetType()}\nFilter已进行错误处理。",
            //    ContentType = "",
            //    StatusCode = (int)HttpStatusCode.InternalServerError
            //};
            context.ExceptionHandled = true;//设置异常已经处理
        }
    }
}
