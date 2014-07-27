using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CoreDdd.Nhibernate.Register.Castle;
using CoreDdd.Register.Castle;
using CoreDdd.UnitOfWorks;
using CoreIoC;
using CoreIoC.Castle;
using Eshop.Commands;
using Eshop.Infrastructure;
using Eshop.Queries;
using Eshop.WebApi.Config;
using Eshop.WebApi.Controllers;

namespace Eshop.WebApi
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

            NhibernateInstaller.SetUnitOfWorkLifeStyle(x => x.PerWebRequest);
            var container = new WindsorContainer();
            container.Install(
                FromAssembly.Containing<QueryExecutorInstaller>(),
                FromAssembly.Containing<QueryHandlerInstaller>(),
                FromAssembly.Containing<CommandHandlerInstaller>(),
                FromAssembly.Containing<ControllerInstaller>(),
                FromAssembly.Containing<NhibernateInstaller>(),
                FromAssembly.Containing<EshopNhibernateInstaller>()
                );
            IoC.Initialize(new CastleContainer(container));

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new IoCHttpControllerActivator());
        }

        public virtual void Application_BeginRequest()
        {
            GetUnitOfWorkPerWebRequest().BeginTransaction();
        }

        public virtual void Application_Error()
        {
            GetUnitOfWorkPerWebRequest().Rollback();
        }

        private IUnitOfWork GetUnitOfWorkPerWebRequest()
        {
            return IoC.Resolve<IUnitOfWork>();
        }  
    }
}