namespace NiaMockApi.DTO.Request
{
    public class AuthenticationRequest
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public DeviceInfoRequest DeviceInfo { get; set; }
    }
}
