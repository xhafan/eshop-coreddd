using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CoreBusClient;
using CoreBusServer;

namespace CoreBus.WebSocket.Tests
{
    public class CoreBusScenario
    {
        public ICoreBusServer Server { get; set; }
        public IDictionary<ICoreBusSession, IList<string>> MessagesFromClientByServerSession { get; set; }
        public IDictionary<ICoreBusClient, IList<string>> MessagesFromServerByClient { get; set; }

        public ICoreBusClient GetClient(int index = 0)
        {
            return MessagesFromServerByClient.Keys.ElementAt(index);
        }

        public ICoreBusSession GetServerSession(int index = 0)
        {
            return MessagesFromClientByServerSession.Keys.ElementAt(index);
        }

        public void WaitUntilServerReceivedMessagesFromClient(int index = 0, int numberOfMessages = 1)
        {
            while (MessagesFromClientByServerSession.Count < index + 1 ||
                   MessagesFromClientByServerSession.ElementAt(index).Value.Count < numberOfMessages)
            {
                Thread.Sleep(10);
            }
        }

        public void WaitUntilClientReceivedMessageFromServer(int index = 0)
        {
            while (MessagesFromServerByClient.ElementAt(index).Value.Count == 0) { }
        }

        public string LastReceivedMessageFromClient(int index = 0)
        {
            return MessagesFromClientByServerSession.ElementAt(index).Value.Last();
        }

        public IList<string> ReceivedMessagesFromClient(int index = 0)
        {
            return MessagesFromClientByServerSession.ElementAt(index).Value;
        }

        public string LastReceivedMessageFromServer(int index = 0)
        {
            return MessagesFromServerByClient.ElementAt(index).Value.Last();
        }

        public IList<string> ReceivedMessageFromServer(int index = 0)
        {
            return MessagesFromServerByClient.ElementAt(index).Value;
        }

        public void Close()
        {
            foreach (var client in MessagesFromServerByClient.Keys)
            {
                client.Close();
            }
            Server.Close();
        }
    }
}