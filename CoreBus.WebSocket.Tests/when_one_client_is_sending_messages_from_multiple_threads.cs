using System.Threading.Tasks;
using CoreBusClient;
using CoreBusClient.WebSocket4Net;
using CoreBusServer.SuperWebSocket;
using NUnit.Framework;
using Shouldly;

namespace CoreBus.WebSocket.Tests
{
    [TestFixture]
    public class when_one_client_is_sending_messages_from_multiple_threads
    {
        private CoreBusScenario _scenario;
        private ICoreBusClient _client;

        [SetUp]
        public void Context()
        {
            _scenario = new CoreBusScenarioBuilder<WebSocketCoreBusServer, WebSocketCoreBusClient>(
                serverListenPort => new WebSocketCoreBusServer(serverListenPort),
                (uri, serverListenPort) => new WebSocketCoreBusClient(uri)
                )
                .Build();
            _client = _scenario.GetClient();
        }

        [Test]
        public void send_multiple_messages_from_one_client_in_multiple_threads()
        {
            var taskOne = SendMultipleMessagesFromClientInNewTask(_client, 5, 20);
            var taskTwo = SendMultipleMessagesFromClientInNewTask(_client, 15, 20);
            taskOne.Wait();
            taskTwo.Wait();
        }

        private Task SendMultipleMessagesFromClientInNewTask(ICoreBusClient client, int numberOfMessagesToBeSent, int expectedTotalNumberOfMessagesReceivedByServer)
        {
            return Task.Factory.StartNew(() =>
            {
                for (var i = 0; i < numberOfMessagesToBeSent; i++)
                {
                    client.Send("Test message");
                }
                _scenario.WaitUntilServerReceivedMessagesFromClient(index: 0, numberOfMessages: expectedTotalNumberOfMessagesReceivedByServer);
                _scenario.ReceivedMessagesFromClient().Count.ShouldBe(expectedTotalNumberOfMessagesReceivedByServer);
            });
        }

        [TearDown]
        public void TearDown()
        {
            _scenario.Close();
        }
    }
}