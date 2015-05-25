using CoreBusServer;

namespace CoreBus.WebSocket.Tests.StartingServerTwice
{
    public interface ICloseServerAct
    {
        void Act(ICoreBusServer server);
    }
}