using System;
using System.Collections.Generic;
using CoreBusClient;
using CoreBusServer;

namespace CoreBus.WebSocket.Tests
{
    public class CoreBusScenarioBuilder<TCoreBusServer, TCoreBusClient>
        where TCoreBusServer : ICoreBusServer
        where TCoreBusClient : ICoreBusClient
    {
        public const int ServerListenPort = 36789;

        private readonly Func<int, TCoreBusServer> _serverFactory;
        private readonly Func<string, int, TCoreBusClient> _clientFactory;

        private int _numberOfClients = 1;
        private readonly string _clientUri = string.Format("ws://localhost:{0}", ServerListenPort);

        public CoreBusScenarioBuilder(
            Func<int, TCoreBusServer> serverFactory,
            Func<string, int, TCoreBusClient> clientFactory
            )
        {
            _clientFactory = clientFactory;
            _serverFactory = serverFactory;
        }

        public CoreBusScenarioBuilder<TCoreBusServer, TCoreBusClient> WithNumberOfClients(int numberOfClients)
        {
            _numberOfClients = numberOfClients;
            return this;
        }

        public CoreBusScenario Build()
        {
            var server = _serverFactory(ServerListenPort);
            IDictionary<ICoreBusSession, IList<string>> messagesFromClientByServerSession = new Dictionary<ICoreBusSession, IList<string>>();
            server.Received += (session, message) =>
            {
                lock (messagesFromClientByServerSession)
                {
                    messagesFromClientByServerSession.GetOrCreateValue(session, () => new List<string>()).Add(message);
                }
            };
            
            IDictionary<ICoreBusClient, IList<string>> messagesFromServerByClient = new Dictionary<ICoreBusClient, IList<string>>();
            for (var i = 0; i < _numberOfClients; i++)
            {
                var client = _clientFactory(_clientUri, ServerListenPort);
                messagesFromServerByClient.Add(client, new List<string>());
                client.Received += message => messagesFromServerByClient[client].Add(message);
            }
            return new CoreBusScenario
            {
                Server = server,
                MessagesFromClientByServerSession = messagesFromClientByServerSession,
                MessagesFromServerByClient = messagesFromServerByClient
            };
        }

        public TCoreBusServer BuildServer(IDictionary<ICoreBusSession, IList<string>> messagesFromClientByServerSession)
        {
            var server = _serverFactory(ServerListenPort);
            server.Received += (session, message) => messagesFromClientByServerSession.GetOrCreateValue(session, () => new List<string>()).Add(message);
            return server;
        }

        public TCoreBusClient BuildClient(IDictionary<ICoreBusClient, IList<string>> messagesFromServerByClient)
        {
            var client = _clientFactory(_clientUri, ServerListenPort);
            messagesFromServerByClient.Add(client, new List<string>());
            client.Received += message => messagesFromServerByClient[client].Add(message);
            return client;
        } 
    }
}