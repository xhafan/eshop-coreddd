using System.Threading.Tasks;
using CoreBusClient;
using CoreBusClient.WebSocket4Net;
using CoreBusServer.SuperWebSocket;
using CoreTest;
using NUnit.Framework;
using Shouldly;

namespace CoreBus.WebSocket.Tests
{
    [TestFixture]
    public class when_sending_multiple_messages_from_multiple_clients_to_server : BaseTest
    {
        private CoreBusScenario _scenario;
        private ICoreBusClient _clientOne;
        private ICoreBusClient _clientTwo;

        [SetUp]
        public void Context()
        {
            _scenario = new CoreBusScenarioBuilder<WebSocketCoreBusServer, WebSocketCoreBusClient>(
                serverListenPort => new WebSocketCoreBusServer(serverListenPort),
                (uri, serverListenPort) => new WebSocketCoreBusClient(uri)
                )
                .WithNumberOfClients(2)
                .Build();
            _clientOne = _scenario.GetClient(0);
            _clientTwo = _scenario.GetClient(1);
        }

        [Test]
        public void send_multiple_messages_from_multiple_clients_to_server()
        {
            var taskOne = SendMultipleMessagesFromClientInNewTask(_clientOne, 0);
            var taskTwo = SendMultipleMessagesFromClientInNewTask(_clientTwo, 1);
            taskOne.Wait();
            taskTwo.Wait();
        }

        private Task SendMultipleMessagesFromClientInNewTask(ICoreBusClient client, int clientIndex)
        {
            return Task.Factory.StartNew(() =>
            {
                const int numberOfMessages = 10;
                for (var i = 0; i < numberOfMessages; i++)
                {
                    client.Send("Test message");
                }
                _scenario.WaitUntilServerReceivedMessagesFromClient(index: clientIndex, numberOfMessages: numberOfMessages);
                _scenario.ReceivedMessagesFromClient(clientIndex).Count.ShouldBe(numberOfMessages);
            });
        }

        [TearDown]
        public void TearDown()
        {
            _scenario.Close();
        }
    }
}