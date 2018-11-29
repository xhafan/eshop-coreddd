using CoreBusClient.WebSocket4Net;
using CoreBusServer.SuperWebSocket;
using NUnit.Framework;
using Shouldly;

namespace CoreBus.WebSocket.Tests.ClientIdExtractors
{
    [TestFixture(TypeArgs = new[] { typeof(SuperWebSocketQueryStringValueClientIdExtractorSpecification) })]
    [TestFixture(TypeArgs = new[] { typeof(SuperWebSocketQueryStringJwtClientIdExtractorSpecification) })]
    public class when_sending_a_message<TClientIdExtractorSpecification>
        where TClientIdExtractorSpecification : IClientIdExtractorSpecification, new()
    {
        private CoreBusScenario _scenario;
        private TClientIdExtractorSpecification _specification;
        private const string TestMessage = "Test message";

        [SetUp]
        public void Context()
        {
            _specification = new TClientIdExtractorSpecification();
            var coreBusClientIdExtractor = _specification.GetCoreBusClientIdExtractor();

            _scenario = new CoreBusScenarioBuilder<WebSocketCoreBusServer, WebSocketCoreBusClient>(
                serverListenPort => new WebSocketCoreBusServer(serverListenPort, coreBusClientIdExtractor),
                (uri, serverListenPort) => new WebSocketCoreBusClient(_specification.GetUri(serverListenPort))
                )
                .Build();
        }

        [Test]
        public void send_message_from_client_to_server()
        {
            _scenario.GetClient().Send(TestMessage);
            _scenario.WaitUntilServerReceivedMessagesFromClient();

            _scenario.GetServerSession().ClientId.ShouldBe(_specification.GetExpectedClientId());
        }

        [TearDown]
        public void TearDown()
        {
            _scenario.Close();
        }
    }
}