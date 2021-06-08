using NiaMockApi.Enums;

namespace NiaMockApi.DTO.Request
{
    public class VerificationFingerRequest 
    {
        public string DataType { get; set; }
        public string Image { get; set; }
        public string PinNumber { get; set; }
        public FingerPosition FingerPosition { get; set; }
    }
}