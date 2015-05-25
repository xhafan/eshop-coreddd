namespace CoreBusClient
{
    public abstract class CoreBusClient : ICoreBusClient
    {
        public abstract void Send(string message);

        public event ReceiveHandler Received = delegate {};

        protected void OnReceived(string message)
        {
            Received(message);
        }

        public abstract void Close();
        public abstract void Dispose();
    }
}