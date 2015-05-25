using CoreBusServer.ClientIdExtractors;
using SuperWebSocket;

namespace CoreBusServer.SuperWebSocket.ClientIdExtractors
{
    public class SuperWebSocketQueryStringValueClientIdExtractor : BaseQueryStringValueCoreBusClientIdExtractor
    {
        public SuperWebSocketQueryStringValueClientIdExtractor(string queryStringKey) 
            : base(queryStringKey)
        {
        }

        protected override string GetPath(object underlyingSession)
        {
            var webSocketSession = (WebSocketSession)underlyingSession;
            return webSocketSession.Path;
        }
    }
}