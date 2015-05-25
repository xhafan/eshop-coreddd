using CoreBusServer;

namespace CoreBus.WebSocket.Tests.StartingServerTwice
{
    public class DisposeServerAct : ICloseServerAct
    {
        public void Act(ICoreBusServer server)
        {
            server.Dispose();
        }
    }
}