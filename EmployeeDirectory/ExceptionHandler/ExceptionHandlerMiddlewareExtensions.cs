using Microsoft.AspNetCore.Diagnostics;

namespace EmployeeDirectory.ExceptionHandler {
    public static class ExceptionHandlerMiddlewareExtensions {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app) {
            app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
