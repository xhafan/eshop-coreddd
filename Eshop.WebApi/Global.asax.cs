using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CoreDdd.Queries;
using CoreIoC;
using Eshop.Infrastructure;
using Eshop.Queries;
using Eshop.WebApi.Config;
using Eshop.WebApi.Controllers;

namespace Eshop.WebApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
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
                FromAssembly.Containing<ControllerInstaller>()
                );
            IoC.Initialize(container);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new IoCHttpControllerActivator());
            UnitOfWorkInitializer.Initialize();
        }
    }
}