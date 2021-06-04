using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace NiaMockApi.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        //private readonly ISecurity _security;

        //public BasicAuthenticationAttribute(ISecurity security)
        //{
        //    _security = security;
        //}

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            //base.OnAuthorization(actionContext);
            else
            {
                var authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                var decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));

                var userNamePasswordArray = decodedAuthenticationToken.Split(":");

                var userName = userNamePasswordArray[0];
                var password = userNamePasswordArray[1];

                //if (_security.Login(userName, password))
                //{
                //     Thread.CurrentPrincipal = new ClaimsPrincipal(new GenericIdentity(userName));
                //}
                //else
                //{
                //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                // }
            }
        }
    }
}
