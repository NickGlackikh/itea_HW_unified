using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace ITEAProject.Services
{
    public interface IWebSocketHandler
    {
        public Task HandleAsync(string userName, WebSocket socket);
    }
}
