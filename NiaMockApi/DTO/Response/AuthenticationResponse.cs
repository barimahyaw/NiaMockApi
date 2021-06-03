using System;

namespace NiaMockApi.DTO.Response
{
    public class AuthenticationResponse
    {
        public bool Success { get; set; }
        public DateTime TimesStamp { get; set; }
        public string Code { get; set; }
        public DataResponse Data { get; set; }

    }
}