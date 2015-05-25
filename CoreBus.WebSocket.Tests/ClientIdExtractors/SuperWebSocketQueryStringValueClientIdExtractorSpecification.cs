using CoreBusServer.ClientIdExtractors;
using CoreBusServer.SuperWebSocket.ClientIdExtractors;

namespace CoreBus.WebSocket.Tests.ClientIdExtractors
{
    public class SuperWebSocketQueryStringValueClientIdExtractorSpecification : IClientIdExtractorSpecification
    {
        public ICoreBusClientIdExtractor GetCoreBusClientIdExtractor()
        {
            return new SuperWebSocketQueryStringValueClientIdExtractor("clientId");
        }

        public string GetUri(int serverListenPort)
        {
            return string.Format("ws://localhost:{0}?clientId={1}", serverListenPort, 23);
        }

        public object GetExpectedClientId()
        {
            return "23";
        }
    }
}