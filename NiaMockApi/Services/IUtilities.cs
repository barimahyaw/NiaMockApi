using NiaMockApi.DTO.Response;

namespace NiaMockApi.Services
{
    public interface IUtilities
    {
        /// <summary>
        /// Write the client authentication token to a json file
        /// </summary>
        /// <param name="response"></param>
        public void GenerateAuthJsonFile(AuthenticationResponse response);

        /// <summary>
        /// Read the client authentication token from the ClientAuthenticationTokenData json file
        /// </summary>
        /// <returns></returns>
        public AuthenticationResponse ReadClientAuthenticationToken();
    }
}