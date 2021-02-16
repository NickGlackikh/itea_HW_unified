using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketProject.Services;

namespace WebSocketProject.Controllers
{
    public class StreamController : Controller
    {
        private readonly IWebSocketHandler _handler;

        public StreamController(IWebSocketHandler handler)
        {
            _handler = handler;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }

        public async Task Get(string username)
        {
            //Проверяем, является ли запрос сокет-запросом
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                //Если сокет-запрос - возвращаем клиенту ответ, что установили подключение 
                WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await _handler.HandleAsync(username, webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        public async Task GetStream()
        {
            //Проверяем, является ли запрос сокет-запросом
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                //Если сокет-запрос - возвращаем клиенту ответ, что установили подключение 
                WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await SendMessage(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        private async Task SendMessage(WebSocket socket)
        {
            byte[] message = Encoding.UTF8.GetBytes("Hello World!");
            //Бесконечный цикл для вывода сообщений
            while(true)
            {
                await socket.SendAsync(new ArraySegment<byte>(message), WebSocketMessageType.Text,true, CancellationToken.None);
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}
