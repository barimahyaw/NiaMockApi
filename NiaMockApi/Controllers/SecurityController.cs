using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiaMockApi.DTO.Request;
using NiaMockApi.DTO.Response;
using NiaMockApi.Services;
using System;
using System.Globalization;

namespace NiaMockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SecurityController : ControllerBase
    {
        private readonly IUtilities _utils;
        private readonly ISecurity _security;

        public SecurityController(IUtilities utils, ISecurity security)
        {
            _utils = utils;
            _security = security;
        }

        [HttpPost]
        //[AuthorizeClient]
        [AllowAnonymous]
        public IActionResult AuthenticationTokenGenerate(AuthenticationRequest request)
        {
            // if (string.IsNullOrWhiteSpace(User.Identity.Name)) return BadRequest();

            var response = AuthenticationResponse(request);

            return Ok(response);

        }

        private AuthenticationResponse AuthenticationResponse(AuthenticationRequest request)
        {
            var response = new AuthenticationResponse
            {
                Success = true,
                TimesStamp = DateTime.Now,
                Code = "200",
                Data = new DataResponse
                {
                    AccessToken = _security.GenerateJwtToken(request),
                    ExpiryDuration = DateTime.UtcNow.AddDays(7).ToString(CultureInfo.InvariantCulture),
                    RefreshToken = Guid.NewGuid().ToString(),
                    TokenType = "Bearer"
                }
            };

            _utils.GenerateAuthJsonFile(response);
            return response;
        }

        [HttpGet]
        //[AuthorizeClient]
        //[Authorize]
        public IActionResult RefreshToken(string refreshToken)
        {
            //if (!User.Identity.IsAuthenticated) return BadRequest();
            if (string.IsNullOrWhiteSpace(refreshToken))
                return BadRequest();

            return Ok(_security.GenerateRefreshedToken(refreshToken));
        }
    }
}
