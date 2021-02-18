using ITEAProject.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITEAProject.Controllers
{
    public class StreamController : Controller
    {
        private readonly IRestApiClient _client;

        public StreamController(IRestApiClient client)
        {
            _client = client;
        }
        public IActionResult Index()
        {
            return View();
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
            while (true)
            {
                byte[] message = Encoding.UTF8.GetBytes(_client.GetString());
                await socket.SendAsync(new ArraySegment<byte>(message), WebSocketMessageType.Text, true, CancellationToken.None);
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }
    }
}
