using CoreBusClient;

namespace CoreBus.WebSocket.Tests.ClosingClient
{
    public class DisposeClientAct : ICloseClientAct
    {
        public void Act(ICoreBusClient client)
        {
            client.Dispose();
        }
    }
}