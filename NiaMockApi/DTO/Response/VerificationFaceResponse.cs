using System;

namespace NiaMockApi.DTO.Response
{
    public class VerificationFaceResponse
    {
        public bool Success { get; set; }
        public bool Code { get; set; }
        public VerificationFaceDataResponse Data { get; set; }
    }

    public class VerificationFaceDataResponse
    {
        public Guid TransactionGuid { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public DateTime ResponseTimestamp { get; set; }
        public bool Verified { get; set; }
    }
}