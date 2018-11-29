using System;
using CoreBusClient.WebSocket4Net;
using CoreBusServer.SuperWebSocket;
using NUnit.Framework;
using Shouldly;

namespace CoreBus.WebSocket.Tests.StartingServerTwice
{
    [TestFixture(TypeArgs = new[] { typeof(CloseServerAct) })]
    [TestFixture(TypeArgs = new[] { typeof(DisposeServerAct) })]
    public class when_starting_server_twice_on_the_same_port<TCloseServerAct>
        where TCloseServerAct : ICloseServerAct, new()
    {
        private CoreBusScenario _scenario;
        private CoreBusScenarioBuilder<WebSocketCoreBusServer, WebSocketCoreBusClient> _scenarioBuilder;
        private TCloseServerAct _closeServerAct;

        [SetUp]
        public void Context()
        {
            _closeServerAct = new TCloseServerAct();

            _scenarioBuilder = new CoreBusScenarioBuilder<WebSocketCoreBusServer, WebSocketCoreBusClient>(
                serverListenPort => new WebSocketCoreBusServer(serverListenPort),
                (uri, serverListenPort) => new WebSocketCoreBusClient(uri)
                );
            _scenario = _scenarioBuilder.Build();
        }

        [Test]
        public void CloseServerAndStartItUpAgainOnTheSamePortAndServerReceivesBothClientMessages()
        {
            _sendMessageToServer();
            _scenario.WaitUntilServerReceivedMessagesFromClient(index: 0, numberOfMessages: 1);

            _scenario.ReceivedMessagesFromClient(0).Count.ShouldBe(1);
            
            _closeServerAndStartItAgain();

            _sendMessageToServer();
            _scenario.WaitUntilServerReceivedMessagesFromClient(index: 1, numberOfMessages: 1);

            _scenario.ReceivedMessagesFromClient(1).Count.ShouldBe(1);
        }

        [Test]
        public void DontCloseServerAndStartItUpAgainOnTheSamePort()
        {
            var ex = Should.Throw<Exception>(() => _scenarioBuilder.BuildServer(_scenario.MessagesFromClientByServerSession));

            ex.Message.ShouldBe("Failed to start WebSocketServer");
        }

        private void _closeServerAndStartItAgain()
        {
            _closeServerAct.Act(_scenario.Server);
            _scenario.Server = _scenarioBuilder.BuildServer(_scenario.MessagesFromClientByServerSession);
        }

        private void _sendMessageToServer()
        {
            _scenario.GetClient().Send("message");
        }

        [TearDown]
        public void TearDown()
        {
            _scenario.Close();
        }
    }
}