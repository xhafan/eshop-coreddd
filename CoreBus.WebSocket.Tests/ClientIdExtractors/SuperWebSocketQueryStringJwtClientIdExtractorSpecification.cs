using System.Collections.Generic;
using CoreBusServer.ClientIdExtractors;
using CoreBusServer.SuperWebSocket.ClientIdExtractors;

namespace CoreBus.WebSocket.Tests.ClientIdExtractors
{
    public class SuperWebSocketQueryStringJwtClientIdExtractorSpecification : IClientIdExtractorSpecification
    {
        private const string SecretKey = "my secret key";
        private const string QueryStringTokenKey = "token";
        private const string JwtClientIdKey = "clientId";

        public ICoreBusClientIdExtractor GetCoreBusClientIdExtractor()
        {
            return new SuperWebSocketQueryStringJwtClientIdExtractor(SecretKey, QueryStringTokenKey, JwtClientIdKey);
        }

        public string GetUri(int serverListenPort)
        {
            return string.Format("ws://localhost:{0}?{1}={2}", serverListenPort, QueryStringTokenKey, _getJwt());
        }

        private string _getJwt()
        {
            var payload = new Dictionary<string, object>
            {
                {JwtClientIdKey, 23}
            };
            return JWT.JsonWebToken.Encode(payload, SecretKey, JWT.JwtHashAlgorithm.HS256);
        }

        public object GetExpectedClientId()
        {
            return 23;
        }
    }
}