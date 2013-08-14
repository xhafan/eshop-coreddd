using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using NUnit.Framework;

namespace CoreWebApiClient.Tests
{
    [SetUpFixture]
    public class RunOncePerTestRun
    {
        public const string TestServerUrl = "http://localhost:54321";

        [SetUp]
        public void SetUp()
        {
            var testServerUri = new Uri(TestServerUrl);
            var config = new HttpSelfHostConfiguration(testServerUri);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            // Create server 
            var server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
            Console.WriteLine("Self hosted web api server running on " + TestServerUrl);            
        }
    }
}
