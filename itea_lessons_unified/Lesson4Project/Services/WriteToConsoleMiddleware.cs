using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4Project.Services
{
    public class WriteToConsoleMiddleWare
    {
        public RequestDelegate _next;
        public string Message; 
        public WriteToConsoleMiddleWare(RequestDelegate next, string message)
        {
            _next = next;
            Message = message;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Custom middleware before "+Message);
            await _next(context);
            Console.WriteLine("Custom middleware after");
        }
    }
}
