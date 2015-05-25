namespace CoreBusServer
{
    public delegate void ReceiveHandler(ICoreBusSession session, string message);
}