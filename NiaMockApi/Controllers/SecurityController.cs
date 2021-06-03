using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NiaMockApi.DTO.Request;
using NiaMockApi.DTO.Response;
using NiaMockApi.Services;
using System;
using System.Globalization;

namespace NiaMockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUtilities _utils;

        public SecurityController(IUtilities utils)
        {
            _utils = utils;
        }

        [HttpPost]
        public IActionResult AuthenticationTokenGenerate(AuthenticationRequest request)
        {
            var response = new AuthenticationResponse
            {
                Success = true,
                TimesStamp = DateTime.Now,
                Code = "200",
                Data = new DataResponse
                {
                    AccessToken = Security.GenerateJwtToken(request),
                    ExpiryDuration = DateTime.UtcNow.AddDays(7).ToString(CultureInfo.InvariantCulture),
                    RefreshToken = Guid.NewGuid().ToString(),
                    TokenType = "Bearer"
                }
            };

            _utils.GenerateAuthJsonFile(response);

            return Ok(response);
        }


    }
}
