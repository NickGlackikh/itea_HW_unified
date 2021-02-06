using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketsExample.Services
{
    public class WebSocketsHandler
    {
        public ConcurrentDictionary<Guid, WebSocket> websocketConnections = new ConcurrentDictionary<Guid, WebSocket>();

        public async Task Handle(Guid connectionGuid, WebSocket webSocket)
        {
            bool addSuccessfully = websocketConnections.TryAdd(connectionGuid, webSocket);

            if (addSuccessfully)
            {

                await SendToAllSockets($"{connectionGuid} joined the chat. ");
                while (webSocket.State == WebSocketState.Open)
                {
                    var message = await Receive(webSocket);
                    if (message!=null)
                    {
                        await SendToAllSockets(message);
                    }
                }
            }
        }

        private async Task SendToAllSockets(string message)
        {
            byte[] messagebyte = Encoding.UTF8.GetBytes(message);
            foreach (var pair in websocketConnections)
            {
                await pair.Value.SendAsync(new ArraySegment<byte>(messagebyte),WebSocketMessageType.Text,true, CancellationToken.None);
            }
        }
        private async Task<string> Receive(WebSocket webSocket)
        {
            ArraySegment<byte> arraySegment = new ArraySegment<byte>(new byte[4096]);
            WebSocketReceiveResult receivedMessage = await webSocket.ReceiveAsync(arraySegment, CancellationToken.None);

            if(receivedMessage.MessageType==WebSocketMessageType.Text)
            {
                return Encoding.UTF8.GetString(arraySegment).TrimEnd('\0') ;
            }

            return null;
        }

        internal Task HandleAsync(string username, WebSocket webSocket)
        {
            throw new NotImplementedException();
        }
    }
}
