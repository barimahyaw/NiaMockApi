using Microsoft.AspNetCore.Mvc;
using System;

namespace NiaMockApi.Attributes
{
    public class AuthorizeClientAttribute : TypeFilterAttribute
    {
        public AuthorizeClientAttribute() : base(typeof(AuthorizationFilter))
        {
            //Arguments = new object[] { type };
        }
    }
}
