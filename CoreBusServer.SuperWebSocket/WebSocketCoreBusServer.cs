using System;
using CoreBusServer.ClientIdExtractors;
using SuperSocket.SocketBase;
using SuperWebSocket;

namespace CoreBusServer.SuperWebSocket
{
    public class WebSocketCoreBusServer : CoreBusServer
    {
        private readonly WebSocketServer _appServer;

        public WebSocketCoreBusServer(int listenPort, ICoreBusClientIdExtractor coreBusClientIdExtractor = null)
            : base(coreBusClientIdExtractor)
        {
            _appServer = new WebSocketServer();
            if (!_appServer.Setup(listenPort))
            {
                throw new Exception("Failed to setup WebSocketServer");
            }
            if (!_appServer.Start())
            {
                throw new Exception("Failed to start WebSocketServer");
            }
            _appServer.NewMessageReceived += _onNewMessageReceived;
            _appServer.SessionClosed += _onSessionClosed;
        }

        protected override ICoreBusSession ConstructCoreBusSession(object clientId, object underlyingSession)
        {
            return new WebSocketCoreBusSession(clientId, (WebSocketSession)underlyingSession);            
        }

        private void _onNewMessageReceived(WebSocketSession underlyingSession, string message)
        {
            if (!IsUnderlyingSessionRegistered(underlyingSession))
            {
                RegisterSession(underlyingSession);
            }
            OnReceived(underlyingSession, message);
        }

        private void _onSessionClosed(WebSocketSession underlyingSession, CloseReason value)
        {
            UnregisterSession(underlyingSession);
        }

        public override void Close()
        {
            _appServer.Stop();
        }

        public override void Dispose()
        {
            _appServer.Dispose();
        }
    }
}