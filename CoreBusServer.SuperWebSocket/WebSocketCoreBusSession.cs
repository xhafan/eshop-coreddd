using SuperWebSocket;

namespace CoreBusServer.SuperWebSocket
{
    public class WebSocketCoreBusSession : ICoreBusSession
    {
        public WebSocketCoreBusSession(object clientId, WebSocketSession underlyingSession)
        {
            ClientId = clientId;
            UnderlyingSession = underlyingSession;
        }

        public object ClientId { get; private set; }
        public object UnderlyingSession { get; private set; }
        
        public void Send(string message)
        {
            ((WebSocketSession)UnderlyingSession).Send(message);
        }
    }
}