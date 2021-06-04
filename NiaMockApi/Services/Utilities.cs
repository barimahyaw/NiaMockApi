using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using NiaMockApi.DTO.Response;
using System.IO;

namespace NiaMockApi.Services
{
    public class Utilities : IUtilities
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public Utilities(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        /// <summary>
        /// Write the client authentication token to a json file
        /// </summary>
        /// <param name="response"></param>
        public void GenerateAuthJsonFile(AuthenticationResponse response)
        {
            var authJson = JsonConvert.SerializeObject(response, Formatting.Indented);

            var path = Path.Combine(_hostEnvironment.ContentRootPath, "ClientAuthenticationTokenData.json");

            File.WriteAllText(path, authJson);
        }

        /// <summary>
        /// Read the client authentication token from the ClientAuthenticationTokenData json file
        /// </summary>
        /// <returns></returns>
        public AuthenticationResponse ReadClientAuthenticationToken()
        {
            var path = Path.Combine(_hostEnvironment.ContentRootPath, "ClientAuthenticationTokenData.json");

            var fileReader = File.ReadAllText(path);

            var tokenData = JsonConvert.DeserializeObject<AuthenticationResponse>(fileReader);

            return tokenData;
        }
    }
}
