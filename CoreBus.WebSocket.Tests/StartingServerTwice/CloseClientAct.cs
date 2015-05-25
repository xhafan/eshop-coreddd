using CoreBusServer;

namespace CoreBus.WebSocket.Tests.StartingServerTwice
{
    public class CloseServerAct : ICloseServerAct
    {
        public void Act(ICoreBusServer server)
        {
            server.Close();
        }
    }
}