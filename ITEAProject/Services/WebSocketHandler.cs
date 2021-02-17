using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITEAProject.Services
{
    public class WebSocketHandler: IWebSocketHandler
    {
        private ConcurrentDictionary<string, WebSocket> webSocketConnectionsString = new ConcurrentDictionary<string, WebSocket>();

        public async Task HandleAsync(string userName, WebSocket socket)
        {
            if (webSocketConnectionsString.TryAdd(userName, socket))
            {
                await SendToAllSockets($"{userName} joined the chat.");
                while (socket.State == WebSocketState.Open)
                {
                    string message = await Receive(userName, socket);
                    if (message != null)
                    {
                        await SendToAllSockets(message);
                    }
                }
            }
        }

        private async Task<string> Receive(string username, WebSocket socket)
        {
            ArraySegment<byte> arraySegment = new ArraySegment<byte>(new byte[4096]);

            WebSocketReceiveResult result = await socket.ReceiveAsync(arraySegment, CancellationToken.None);
            
            if (result.MessageType==WebSocketMessageType.Text)
            {
                string message = Encoding.UTF8.GetString(arraySegment.ToArray()).TrimEnd('\0');
                return $"<b>{username}:</b>" + message;
            }

            return null;
        }

        private async Task SendToAllSockets(string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            foreach (var pair in webSocketConnectionsString)
            {
                await pair.Value.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
