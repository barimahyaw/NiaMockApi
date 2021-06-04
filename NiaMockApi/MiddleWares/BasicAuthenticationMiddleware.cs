using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NiaMockApi.MiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BasicAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var authorization = httpContext.Request.Headers["Authorization"];
            if (authorization.ToString() == null)
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            //base.OnAuthorization(actionContext);
            else
            {
                
                var authenticationToken = authorization.ToString().Substring("Bearer".Length).Trim();
                
                var jwt = authenticationToken;
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);

                //var decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(token.ToString()));

                //var userNamePasswordArray = decodedAuthenticationToken.Split(":");

                //var userName = userNamePasswordArray[0];
                //var password = userNamePasswordArray[1];

                var tokenClaims  = token.Claims.ToArray();

                var userName = tokenClaims[0].ToString();


                //if (_security.Login(userName, password))
                //{
                    Thread.CurrentPrincipal = new ClaimsPrincipal(new GenericIdentity(userName));
                //}
                //else
                //{
                //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                // }
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BasicAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthenticationMiddleware>();
        }
    }
}
