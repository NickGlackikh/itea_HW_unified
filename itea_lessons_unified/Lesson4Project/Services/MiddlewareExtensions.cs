using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseWriteToConsole(this IApplicationBuilder app, string output)
        {
            return app.UseMiddleware<WriteToConsoleMiddleWare>(output);
        }
    }
}
