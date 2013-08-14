using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using CoreIoC;

namespace Eshop.WebApi
{
    public class IoCHttpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)IoC.Resolve(controllerType);
        }
    }
}