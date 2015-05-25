using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using CoreBusServer.ClientIdExtractors;

namespace CoreBusServer
{
    public abstract class CoreBusServer : ICoreBusServer
    {
        private readonly IDictionary<object, ISet<ICoreBusSession>> _sessionsByClientId =
            new Dictionary<object, ISet<ICoreBusSession>>();

        private readonly ConcurrentDictionary<object, ICoreBusSession> _coreBusSessionsByUnderlyingSession =
            new ConcurrentDictionary<object, ICoreBusSession>();

        private readonly ICoreBusClientIdExtractor _coreBusClientIdExtractor;

        protected CoreBusServer(ICoreBusClientIdExtractor coreBusClientIdExtractor = null)
        {
            _coreBusClientIdExtractor = coreBusClientIdExtractor ?? new AnonymousCoreBusClientIdExtractor();
        }

        protected abstract ICoreBusSession ConstructCoreBusSession(object clientId, object underlyingSession);

        protected void RegisterSession(object underlyingSession)
        {
            var clientId = _coreBusClientIdExtractor.ExtractClientId(underlyingSession);
            var coreBusSession = ConstructCoreBusSession(clientId, underlyingSession);                        
            
            lock (_sessionsByClientId)
            {
                _sessionsByClientId.GetOrCreateValue(coreBusSession.ClientId, () => new HashSet<ICoreBusSession>()).Add(coreBusSession);
            }
            _coreBusSessionsByUnderlyingSession.TryAdd(coreBusSession.UnderlyingSession, coreBusSession);
        }
       
        protected void UnregisterSession(object underlyingSession)
        {
            var coreBusSession = _coreBusSessionsByUnderlyingSession[underlyingSession];
            var clientId = coreBusSession.ClientId;
            lock (_sessionsByClientId)
            {
                var clientSessions = _sessionsByClientId[clientId];                
                clientSessions.Remove(coreBusSession);
                if (!clientSessions.Any())
                {
                    _sessionsByClientId.Remove(clientId);
                }
            }
            _coreBusSessionsByUnderlyingSession.TryRemove(underlyingSession, out coreBusSession);
        }

        public void Send(object clientId, string message)
        {
            ISet<ICoreBusSession> sessions;
            lock (_sessionsByClientId)
            {
                if (!_sessionsByClientId.TryGetValue(clientId, out sessions)) return;                
            }

            foreach (var session in sessions) // todo: locking is missing here
            {
                session.Send(message);
            }
        }

        public event ReceiveHandler Received = delegate {};

        protected void OnReceived(object underlyingSession, string message)
        {
            var coreBusSession = _coreBusSessionsByUnderlyingSession[underlyingSession];
            Received(coreBusSession, message);
        }

        protected bool IsUnderlyingSessionRegistered(object underlyingSession)
        {
            return _coreBusSessionsByUnderlyingSession.ContainsKey(underlyingSession);
        }

        public abstract void Close();
        public abstract void Dispose();
    }
}