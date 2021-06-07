using NiaMockApi.DTO.Request;
using NiaMockApi.DTO.Response;

namespace NiaMockApi.Services
{
    public interface ISecurity
    {
        /// <summary>
        /// Authenticate client against access token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        string GenerateJwtToken(AuthenticationRequest request);

        bool Login(string userName, string password);

        /// <summary>
        /// Refresh Client Token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public AuthenticationResponse GenerateRefreshedToken(string refreshToken);
    }
}