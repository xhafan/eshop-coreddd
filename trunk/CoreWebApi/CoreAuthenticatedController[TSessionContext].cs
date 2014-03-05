namespace CoreWebApi
{
    public abstract class CoreAuthenticatedController<TSessionContext> : CoreAuthenticatedController
    {
        public TSessionContext SessionContext
        {
            get { return (TSessionContext) SessionContextObject; }
            set { SessionContextObject = value; }
        }
    }
}