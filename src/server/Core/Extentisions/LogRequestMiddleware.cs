using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extentisions
{
    public class LogRequestMiddleware
    {
        private RequestDelegate _next;
        private ILog _log;

        public LogRequestMiddleware(RequestDelegate next, ILog log)
        {
            _next = next;
            _log = log;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            string requestBody;
            using (var stream = new MemoryStream())
            {
                // make sure that body is read from the beginning
                httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                httpContext.Request.Body.CopyTo(stream);
                requestBody = Encoding.UTF8.GetString(stream.ToArray());

                // this is required, otherwise model binding will return null
                httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            }

            if (httpContext.User.Identity.IsAuthenticated)
                log4net.LogicalThreadContext.Properties["username"] = httpContext.User.Identity.Name;
            log4net.LogicalThreadContext.Properties["request_method"] = httpContext.Request.Method;
            log4net.LogicalThreadContext.Properties["request_url"] = UriHelper.GetDisplayUrl(httpContext.Request);
            log4net.LogicalThreadContext.Properties["request_body"] = requestBody;
            log4net.LogicalThreadContext.Properties["correlationId"] = Guid.NewGuid();

            _log.Info("Request Log");

            await _next(httpContext);
        }
    }
}
