using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using NiaMockApi.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace NiaMockApi.Attributes
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly ISecurity _security;

        public AuthorizationFilter(ISecurity security)
        {
            _security = security;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authenticationToken = context.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrWhiteSpace(authenticationToken))
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else
            {
                authenticationToken = authenticationToken.Substring("Bearer".Length).Trim();

                var jwt = authenticationToken;
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);
                var userNamePasswordArray = token.Claims.ToArray();

                //var decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));

                //var userNamePasswordArray = decodedAuthenticationToken.Split(":");

                var userName = userNamePasswordArray[0].ToString();
                var password = userNamePasswordArray[1].ToString();

                if (_security.Login(userName, password))
                {
                    Thread.CurrentPrincipal = new ClaimsPrincipal(new GenericIdentity(userName));
                }
                else
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                }
            }
        }
    }
}
