namespace CoreBusServer
{
    public interface ICoreBusSession
    {
        object ClientId { get; }
        object UnderlyingSession { get; }
        void Send(string message);
    }
}