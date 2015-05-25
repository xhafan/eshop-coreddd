namespace CoreBusServer.ClientIdExtractors
{
    public interface ICoreBusClientIdExtractor
    {
        object ExtractClientId(object underlyingSession);
    }
}