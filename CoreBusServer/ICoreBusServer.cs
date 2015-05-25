using System;

namespace CoreBusServer
{
    public interface ICoreBusServer : IDisposable
    {
        void Send(object clientId, string message);
        event ReceiveHandler Received;
        void Close();
    }
}
