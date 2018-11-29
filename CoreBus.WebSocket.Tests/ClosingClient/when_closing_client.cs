using System.Threading;
using CoreBusClient;
using CoreBusClient.WebSocket4Net;
using CoreBusServer.SuperWebSocket;
using NUnit.Framework;
using Shouldly;

namespace CoreBus.WebSocket.Tests.ClosingClient
{
    [TestFixture(TypeArgs = new[] { typeof(CloseClientAct) })]
    [TestFixture(TypeArgs = new[] { typeof(DisposeClientAct) })]
    public class when_closing_client<TCloseClientAct>
        where TCloseClientAct : ICloseClientAct, new()
    {
        private CoreBusScenario _scenario;
        private ICoreBusClient _client;
        private TCloseClientAct _closeClientAct;
        private CoreBusScenarioBuilder<WebSocketCoreBusServer, WebSocketCoreBusClient> _scenarioBuilder;

        [SetUp]
        public void Context()
        {
            _closeClientAct = new TCloseClientAct();

            _scenarioBuilder = new CoreBusScenarioBuilder<WebSocketCoreBusServer, WebSocketCoreBusClient>(
                serverListenPort => new WebSocketCoreBusServer(serverListenPort),
                (uri, serverListenPort) => new WebSocketCoreBusClient(uri)
                );
            _scenario = _scenarioBuilder.Build();
            _client = _scenario.GetClient();
        }

        [Test]
        public void CloseClientAndConnectItAgainAndSendMessageToServer()
        {
            _sendMessageToServer();
            _scenario.WaitUntilServerReceivedMessagesFromClient(index: 0);
            _scenario.ReceivedMessagesFromClient(0).Count.ShouldBe(1);

            _closeClientAct.Act(_client);

            Thread.Sleep(100);
            _sendMessageToClient();
            Thread.Sleep(100);
            _scenario.ReceivedMessageFromServer().Count.ShouldBe(0);

            _closeClientAndCreateNewClient();
            _sendMessageToServer();
           _scenario.WaitUntilServerReceivedMessagesFromClient(index: 1);

           _scenario.ReceivedMessagesFromClient(1).Count.ShouldBe(1);
        }

        private void _closeClientAndCreateNewClient()
        {
            _client = _scenarioBuilder.BuildClient(_scenario.MessagesFromServerByClient);
        }

        private void _sendMessageToServer()
        {
            _client.Send("message from client");
        }

        private void _sendMessageToClient()
        {
            var clientId = _scenario.GetServerSession().ClientId;
            _scenario.Server.Send(clientId, "message from server");
        }

        [TearDown]
        public void TearDown()
        {
            _scenario.Close();
        }
    }
}