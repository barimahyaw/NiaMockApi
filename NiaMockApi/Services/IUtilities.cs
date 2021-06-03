using NiaMockApi.DTO.Response;

namespace NiaMockApi.Services
{
    public interface IUtilities
    {
        void GenerateAuthJsonFile(AuthenticationResponse response);
    }
}