using CoreBusServer.ClientIdExtractors;

namespace CoreBus.WebSocket.Tests.ClientIdExtractors
{
    public interface IClientIdExtractorSpecification
    {
        ICoreBusClientIdExtractor GetCoreBusClientIdExtractor();
        string GetUri(int serverListenPort);
        object GetExpectedClientId();
    }
}