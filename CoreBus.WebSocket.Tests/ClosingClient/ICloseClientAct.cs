using CoreBusClient;

namespace CoreBus.WebSocket.Tests.ClosingClient
{
    public interface ICloseClientAct
    {
        void Act(ICoreBusClient client);
    }
}