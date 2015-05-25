using CoreBusClient;

namespace CoreBus.WebSocket.Tests.ClosingClient
{
    public class CloseClientAct : ICloseClientAct
    {
        public void Act(ICoreBusClient client)
        {
            client.Close();
        }
    }
}