using System.Data;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CoreDdd.Infrastructure;
using CoreDdd.Queries;
using CoreIoC;
using Eshop.Commands;
using Eshop.Infrastructure;
using Eshop.Queries;
using Eshop.WebApi2.Config;
using Eshop.WebApi2.Controllers;

namespace Eshop.WebApi2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class UnitOfWorkWebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            var container = new WindsorContainer();
            container.Install(
                FromAssembly.Containing<QueryExecutorInstaller>(),
                FromAssembly.Containing<QueryHandlerInstaller>(),
                FromAssembly.Containing<CommandHandlerInstaller>(),
                FromAssembly.Containing<ControllerInstaller>()
                );
            IoC.Initialize(container);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new IoCHttpControllerActivator());
            UnitOfWorkInitializer.Initialize();
        }

        public virtual void Application_BeginRequest()
        {
            UnitOfWork.Current.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public virtual void Application_EndRequest()
        {
            if (!UnitOfWork.IsStarted) return;
            UnitOfWork.Current.TransactionalFlush();
            UnitOfWork.Current.Dispose();
        }

        public virtual void Application_Error()
        {
            if (!UnitOfWork.IsStarted) return;
            UnitOfWork.Current.TransactionalRollback();
            UnitOfWork.Current.Dispose();
        }
    }
}