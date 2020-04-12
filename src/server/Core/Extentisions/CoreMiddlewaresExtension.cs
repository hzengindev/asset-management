using Microsoft.AspNetCore.Builder;

namespace Core.Extentisions
{
    public static class CoreMiddlewaresExtension
    {
        public static void UseCoreMiddlewaresExtension(this IApplicationBuilder builder)
        {
            //builder.UseMiddleware<EnableRequestRewindMiddleware>();
            //builder.UseMiddleware<LogRequestMiddleware>();
            //builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}