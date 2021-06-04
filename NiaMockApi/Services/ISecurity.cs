using NiaMockApi.DTO.Request;

namespace NiaMockApi.Services
{
    public interface ISecurity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        string GenerateJwtToken(AuthenticationRequest request);

        bool Login(string userName, string password);
    }
}