namespace NiaMockApi.DTO.Request
{
    public class VerificationFaceRequest
    {
        public string DataType { get; set; }
        public string Image { get; set; }
        public string PinNumber { get; set; }
    }
}