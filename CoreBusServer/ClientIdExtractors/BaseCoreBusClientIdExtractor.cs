using System;

namespace CoreBusServer.ClientIdExtractors
{
    public abstract class BaseCoreBusClientIdExtractor : ICoreBusClientIdExtractor
    {
        public abstract object ExtractClientId(object underlyingSession);

        protected Guid GetNewAnonymousClientGuid()
        {
            return Guid.NewGuid();
        }
    }
}