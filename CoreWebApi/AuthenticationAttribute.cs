using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;
using System.Linq;
using Newtonsoft.Json;

namespace CoreWebApi
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        private readonly Type _sessionContextType;
        private readonly string _autheticationCookieName = FormsAuthentication.FormsCookieName;

        public AuthenticationAttribute(Type sessionContextType)
        {
            _sessionContextType = sessionContextType;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            var authenticatedController = actionContext.ControllerContext.Controller as CoreAuthenticatedController;
            if (authenticatedController == null) return;

            var cookieHeaderValue = actionContext.Request.Headers.GetCookies(_autheticationCookieName).FirstOrDefault();
            if (cookieHeaderValue == null) return;
            var cookie = cookieHeaderValue.Cookies.FirstOrDefault();
            if (cookie == null) return;

            var formsAuthenticationTicket = FormsAuthentication.Decrypt(cookie.Value);
            if (formsAuthenticationTicket == null) return;

            authenticatedController.SessionContextObject = JsonConvert.DeserializeObject(formsAuthenticationTicket.UserData, _sessionContextType);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var authenticatedController = actionExecutedContext.ActionContext.ControllerContext.Controller as CoreAuthenticatedController;
            if (authenticatedController == null) return;

            if (authenticatedController.SessionContextObject == null) return;

            var serializedSessionContext = JsonConvert.SerializeObject(authenticatedController.SessionContextObject);
            var formsTicket = new FormsAuthenticationTicket(
                1,
                "Anonymous",
                DateTime.Now,
                DateTime.MaxValue,
                true,
                serializedSessionContext
            );
            var encryptedTicket = FormsAuthentication.Encrypt(formsTicket);
            actionExecutedContext.Response.Headers.AddCookies(new[] { new CookieHeaderValue(_autheticationCookieName, encryptedTicket) });
        }
    }
}