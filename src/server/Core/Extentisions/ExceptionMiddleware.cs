using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Core.Extentisions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        private IHostingEnvironment _env;
        private ILog _log;

        public ExceptionMiddleware(RequestDelegate next, IHostingEnvironment env, ILog log)
        {
            _next = next;
            _env = env;
            _log = log;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e, _env, _log);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e, IHostingEnvironment env, ILog log)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //Logging with log4net
            log.Error(e.Message, e);

            if (env.IsDevelopment())
            {
                return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    success = false,
                    errorMessage = e.Message,
                    correlationId = log4net.LogicalThreadContext.Properties["correlationId"],
                    stackTrace = e.StackTrace
                }));
            }

            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                success = false,
                errorMessage = "Genel bir sorun oluştu.",
                errorCode = 1000,
                correlationId = log4net.LogicalThreadContext.Properties["correlationId"],
            }));
        }
    }
}
