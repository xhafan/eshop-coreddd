using System;
using CoreBusServer;
using CoreBusServer.SuperWebSocket;
using CoreBusServer.SuperWebSocket.ClientIdExtractors;

namespace CoreBusServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var coreBusServer = new WebSocketCoreBusServer(44961, new SuperWebSocketQueryStringJwtClientIdExtractor("HafsSecret", "token", "clientId"));
            coreBusServer.Received += OnReceived;

            string line;
            while ((line = Console.ReadLine()) != null)
            {
                coreBusServer.Send("Haf", line);
            }
        }

        static void OnReceived(ICoreBusSession session, string message)
        {
            Console.WriteLine("message received from client {0}: {1}", session.ClientId, message);
        }
    }
}
