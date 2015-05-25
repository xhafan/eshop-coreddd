using CoreBusClient.WebSocket4Net;
using CoreBusServer.SuperWebSocket;
using CoreTest;
using NUnit.Framework;
using Shouldly;

namespace CoreBus.WebSocket.Tests
{
    [TestFixture]
    public class when_sending_a_message : BaseTest
    {
        private CoreBusScenario _scenario;
        private const string TestMessage = "Test message";

        [SetUp]
        public void Context()
        {
            _scenario = new CoreBusScenarioBuilder<WebSocketCoreBusServer, WebSocketCoreBusClient>(
                serverListenPort => new WebSocketCoreBusServer(serverListenPort),
                (uri, serverListenPort) => new WebSocketCoreBusClient(uri)
                ).Build();
        }

        [Test]
        public void send_message_from_client_to_server()
        {
            _scenario.GetClient().Send(TestMessage);
            _scenario.WaitUntilServerReceivedMessagesFromClient();

            _scenario.LastReceivedMessageFromClient().ShouldBe(TestMessage);
        }

        [Test]
        public void send_message_from_server_to_client()
        {
            _scenario.GetClient().Send("whatever");
            _scenario.WaitUntilServerReceivedMessagesFromClient();
            var clientId = _scenario.GetServerSession().ClientId;
            _scenario.Server.Send(clientId, TestMessage);
            _scenario.WaitUntilClientReceivedMessageFromServer();

            _scenario.LastReceivedMessageFromServer().ShouldBe(TestMessage);
        }

        [TearDown]
        public void TearDown()
        {
            _scenario.Close();
        }
    }
}