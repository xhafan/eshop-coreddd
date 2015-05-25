using System;
using System.Collections.Generic;
using CoreBusClient.WebSocket4Net;

namespace CoreBusClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var token = GetJwt();
                var coreBusClient = new WebSocketCoreBusClient(string.Format("ws://localhost:44961/wsapp?token={0}", token));
                coreBusClient.Received += OnReceived;

                coreBusClient.Send("Hello from client");

                string line;
                while ((line = Console.ReadLine()) != null)
                {
                    coreBusClient.Send(line);
                }
            }
            catch (AggregateException ex)
            { 
                Console.WriteLine(ex.Flatten());
            }
        }

        private static string GetJwt()
        {
            var payload = new Dictionary<string, object>
            {
                {"clientId", "Haf"}
            };
            const string secretKey = "HafsSecret";
            return JWT.JsonWebToken.Encode(payload, secretKey, JWT.JwtHashAlgorithm.HS256);
        }

        private static void OnReceived(string message)
        {
            Console.WriteLine("Received: " + message);
        }
    }
}
