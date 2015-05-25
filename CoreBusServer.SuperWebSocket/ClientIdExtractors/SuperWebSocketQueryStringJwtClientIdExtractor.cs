using CoreBusServer.ClientIdExtractors;
using SuperWebSocket;

namespace CoreBusServer.SuperWebSocket.ClientIdExtractors
{
    public class SuperWebSocketQueryStringJwtClientIdExtractor : BaseQueryStringJwtCoreBusClientIdExtractor
    {
        public SuperWebSocketQueryStringJwtClientIdExtractor(string secretKey, string queryStringTokenKey, string jwtClientIdKey)
            : base(secretKey, queryStringTokenKey, jwtClientIdKey)
        {
        }

        protected override string GetPath(object underlyingSession)
        {
            var webSocketSession = (WebSocketSession)underlyingSession;
            return webSocketSession.Path;
        }
    }
}