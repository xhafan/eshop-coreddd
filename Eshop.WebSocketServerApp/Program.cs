using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using SuperWebSocket;

namespace Eshop.WebSocketServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var appServer = new WebSocketServer();
            if (!appServer.Setup(44961)) throw new Exception("Failed to setup");
            if (!appServer.Start()) throw new Exception("Failed to start");
            appServer.NewDataReceived += AppServerOnNewDataReceived;
            appServer.NewMessageReceived += appServer_NewMessageReceived;
            appServer.NewSessionConnected += session => Console.WriteLine("New session connected");

            Console.WriteLine("WebSocket server started");
            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
            }

            appServer.Stop();
        }

        private static bool _hasMessageLength;
        private static int _messageLength;
        private static byte[] message;
        private static int _currentOffset;


        private static void AppServerOnNewDataReceived(WebSocketSession session, byte[] value)
        {
            if (!_hasMessageLength)
            {
                _hasMessageLength = true;
                _messageLength = BitConverter.ToInt32(value, 0);
                message = new byte[_messageLength];
                var length = value.Length - 4;
                Array.Copy(value, 4, message, 0, length);
                _currentOffset = length;
            }
            else
            {
                Array.Copy(value, 0, message, _currentOffset, value.Length);
                _currentOffset += value.Length;
                if (_currentOffset == _messageLength)
                {
                    var sha = new SHA256Managed();
                    var hash = sha.ComputeHash(message);
                    Console.WriteLine("Hurray: " + BitConverter.ToString(hash));
                }
            }
        }

        static void appServer_NewMessageReceived(WebSocketSession session, string message)
        {
            Console.WriteLine(message);
            session.Send("Server: " + message);
        }
    }
}
