using System.Web;

namespace CoreBusServer.ClientIdExtractors
{
    public abstract class BaseQueryStringCoreBusClientIdExtractor : BaseCoreBusClientIdExtractor
    {
        private readonly string _queryStringKey;

        protected BaseQueryStringCoreBusClientIdExtractor(string queryStringKey)
        {
            _queryStringKey = queryStringKey;
        }

        protected abstract string GetPath(object underlyingSession);

        protected string ExtractQueryStringValue(object underlyingSession)
        {
            var path = GetPath(underlyingSession);
            var indexOfQueryString = path.IndexOf("?");
            if (indexOfQueryString == -1)
            {
                return null;
            }
            var queryString = path.Substring(indexOfQueryString + 1);
            return HttpUtility.ParseQueryString(queryString).Get(_queryStringKey);
        }
    }
}