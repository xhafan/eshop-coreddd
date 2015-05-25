namespace CoreBusServer.ClientIdExtractors
{
    public abstract class BaseQueryStringValueCoreBusClientIdExtractor : BaseQueryStringCoreBusClientIdExtractor
    {
        protected BaseQueryStringValueCoreBusClientIdExtractor(string queryStringKey) 
            : base(queryStringKey)
        {
        }

        public override object ExtractClientId(object underlyingSession)
        {
            var value = ExtractQueryStringValue(underlyingSession);
            return !string.IsNullOrWhiteSpace(value)  
                ? (object)value
                : GetNewAnonymousClientGuid();
        }
    }
}