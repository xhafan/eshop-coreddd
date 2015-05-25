using System;

namespace CoreBusClient
{
    public interface ICoreBusClient : IDisposable
    {
        void Send(string message);
        event ReceiveHandler Received;
        void Close();
    }
}
