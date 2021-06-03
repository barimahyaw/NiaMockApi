namespace NiaMockApi.DTO.Response
{
    public class DataResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string TokenType { get; set; }
        public string ExpiryDuration { get; set; }
    }
}