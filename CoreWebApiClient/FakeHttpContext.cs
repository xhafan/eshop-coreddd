using System;
using System.Web;

namespace CoreWebApiClient
{
    // http://www.klopfenstein.net/lorenz.aspx/url-generation-in-asp-net-mvc-without-httpcontext
    internal class FakeHttpContext : HttpContextBase
    {
        private readonly HttpRequestBase _request;
        private readonly HttpResponseBase _response = new FakeHttpResponse();

        public FakeHttpContext(string applicationPath)
        {
            _request = new FakeHttpRequest(applicationPath);
        }

        public override HttpRequestBase Request
        {
            get
            {
                return _request;
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return _response;
            }
        }

        class FakeHttpRequest : HttpRequestBase
        {
            private readonly string _appPath;

            public FakeHttpRequest(string appPath)
            {
                if (appPath == null)
                    throw new ArgumentNullException();

                _appPath = appPath;
            }

            public override string ApplicationPath
            {
                get
                {
                    return _appPath;
                }
            }
        }

        class FakeHttpResponse : HttpResponseBase
        {
            public override string ApplyAppPathModifier(string virtualPath)
            {
                return virtualPath;
            }
        }
    }
}