using System;
using System.Threading;
using CoreBusClient.WebSocket4Net;
using CoreBusServer.SuperWebSocket;
using CoreTest;
using NUnit.Framework;
using Shouldly;

namespace CoreBus.WebSocket.Tests
{
    [TestFixture]
    public class when_sending_message_to_server_which_is_not_started : BaseTest
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

            _scenario.Server.Close();
        }

        [Test]
        public void send_message_from_client_to_server()
        {
            _scenario.GetClient().Send(TestMessage);
            Thread.Sleep(2000);

            _scenario.ReceivedMessageFromServer().Count.ShouldBe(0);
        }

        [TearDown]
        public void TearDown()
        {
            _scenario.Close();
        }
    }
}