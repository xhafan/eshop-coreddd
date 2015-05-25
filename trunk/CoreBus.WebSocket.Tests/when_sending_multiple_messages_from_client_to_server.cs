using CoreBusClient.WebSocket4Net;
using CoreBusServer.SuperWebSocket;
using CoreTest;
using NUnit.Framework;
using Shouldly;

namespace CoreBus.WebSocket.Tests
{
    [TestFixture]
    public class when_sending_multiple_messages_from_client_to_server : BaseTest
    {
        private CoreBusScenario _scenario;

        [SetUp]
        public void Context()
        {
            _scenario = new CoreBusScenarioBuilder<WebSocketCoreBusServer, WebSocketCoreBusClient>(
                serverListenPort => new WebSocketCoreBusServer(serverListenPort),
                (uri, serverListenPort) => new WebSocketCoreBusClient(uri)
                ).Build();
        }

        [Test]
        public void send_two_messages_from_client_to_server()
        {
            const string testMessageOne = "Test message 1";
            const string testMessageTwo = "Test message 2";
            _scenario.GetClient().Send(testMessageOne);
            _scenario.GetClient().Send(testMessageTwo);
            _scenario.WaitUntilServerReceivedMessagesFromClient(index: 0, numberOfMessages: 2);

            _scenario.ReceivedMessagesFromClient().ShouldBe(new[] {testMessageOne, testMessageTwo});
        }

        [Test]
        public void send_multiple_messages_from_client_to_server()
        {
            const string testMessage = "Test message";
            for (var i = 0; i < 100; i++)
            {
                _scenario.GetClient().Send(testMessage);                
            }
            _scenario.WaitUntilServerReceivedMessagesFromClient(index: 0, numberOfMessages: 100);

            _scenario.ReceivedMessagesFromClient().Count.ShouldBe(100);
        }

        [TearDown]
        public void TearDown()
        {
            _scenario.Close();
        }
    }
}