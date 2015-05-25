namespace CoreBusServer.ClientIdExtractors
{
    public class AnonymousCoreBusClientIdExtractor : BaseCoreBusClientIdExtractor
    {
        public override object ExtractClientId(object underlyingSession)
        {
            return GetNewAnonymousClientGuid();
        }
    }
}