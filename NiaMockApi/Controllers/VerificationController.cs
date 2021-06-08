using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiaMockApi.DTO.Request;
using NiaMockApi.DTO.Response;
using NiaMockApi.Services;

namespace NiaMockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VerificationController : ControllerBase
    {
        [HttpPost("kycVerificationFinger")]
        public VerificationFingerResponse KycVerificationFinger(VerificationFingerRequest request)
        {
            return Verification.KycVerificationFinger(request);
        }
    }
}
