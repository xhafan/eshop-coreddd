using System;
using System.Collections.Generic;

namespace CoreBusServer.ClientIdExtractors
{
    public abstract class BaseQueryStringJwtCoreBusClientIdExtractor : BaseQueryStringCoreBusClientIdExtractor
    {
        private readonly string _secretKey;
        private readonly string _jwtClientIdKey;

        protected BaseQueryStringJwtCoreBusClientIdExtractor(string secretKey, string queryStringTokenKey, string jwtClientIdKey)
            : base(queryStringTokenKey)
        {
            _secretKey = secretKey;
            _jwtClientIdKey = jwtClientIdKey;
        }

        public override object ExtractClientId(object underlyingSession)
        {
            var token = ExtractQueryStringValue(underlyingSession);
            return !string.IsNullOrWhiteSpace(token)  
                ? ExtractClientFromToken(token)
                : GetNewAnonymousClientGuid();
        }

        private object ExtractClientFromToken(string token)
        {
            try
            {
                var jsonPayloadAsDictionary = (Dictionary<string, object>)JWT.JsonWebToken.DecodeToObject(token, _secretKey);
                return jsonPayloadAsDictionary[_jwtClientIdKey];
            }
            catch (JWT.SignatureVerificationException) // todo: test these exceptions
            {
                return GetNewAnonymousClientGuid();
            }
            catch (InvalidCastException)
            {
                return GetNewAnonymousClientGuid();
            }
            catch (KeyNotFoundException)
            {
                return GetNewAnonymousClientGuid();
            }
        }
    }
}