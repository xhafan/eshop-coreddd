using System;
using System.Security.Cryptography;
using WebSocket4Net;

namespace Eshop.WebSocketClientApp
{
    class Program
    {
        private static WebSocket _webSocket;

        static void Main(string[] args)
        {
            _webSocket = new WebSocket("ws://localhost:44961/wsapp?token=ABCD");
            _webSocket.Opened += WebSocketOnOpened;
            _webSocket.Closed += (sender, eventArgs) => Console.WriteLine("Closed");
            _webSocket.Error += (sender, eventArgs) => Console.WriteLine("Error" + eventArgs.Exception);
            _webSocket.MessageReceived += (sender, eventArgs) => Console.WriteLine(eventArgs.Message);
            _webSocket.DataReceived += (sender, eventArgs) => Console.WriteLine("Data received");

            _webSocket.Open();

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
            }



            _webSocket.Close();
        }

        private static void WebSocketOnOpened(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Connection opened");            
            Console.WriteLine("Sending message");

            const int length = 10000023;
            var bytes = new byte[length];
            new Random().NextBytes(bytes);
            var intBytes = BitConverter.GetBytes(length);
            
            _webSocket.Send(intBytes, 0, 4);
            const int packetLength = 1000;
            for (var i = 0; i < length / packetLength; i++)
            {
                _webSocket.Send(bytes, i * packetLength, packetLength);
            }
            const int lastOffset = ((length / packetLength) * packetLength);
            const int remainingLength = length - lastOffset;
            _webSocket.Send(bytes, lastOffset, remainingLength);

            var sha = new SHA256Managed();
            var hash = sha.ComputeHash(bytes);
            Console.WriteLine("Hurray: " + BitConverter.ToString(hash));
        }
    }
}
