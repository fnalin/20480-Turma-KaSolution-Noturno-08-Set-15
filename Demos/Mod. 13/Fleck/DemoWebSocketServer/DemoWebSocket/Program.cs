using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleck;

namespace DemoWebSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            var webSocketServer = new WebSocketServer("ws://127.0.0.1:8081");
            var sockets = new List<IWebSocketConnection>();

            webSocketServer.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    sockets.Add(socket);
                };

                socket.OnMessage = mensagem =>
                {
                    foreach (var s in sockets)
                    {
                        s.Send(mensagem);
                    }
                };

                socket.OnClose = () =>
                {
                    sockets.Remove(socket);
                };
            });

            Console.ReadKey();
        }
    }
}
