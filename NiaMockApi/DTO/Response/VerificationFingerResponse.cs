using System;

namespace NiaMockApi.DTO.Response
{
    public class VerificationFingerResponse
    {
        public string Code { get; set; }
        public bool Success { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public Guid TransactionGuid { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public DateTime ResponseTimestamp { get; set; }
        public bool Verified { get; set; }
        public Person Person { get; set; }
    }

    public class Person
    {
        public string NationalId { get; set; }
        public string CardValidTo { get; set; }
        public string Surname { get; set; }
        public string Forenames { get; set; }
        public string Nationality { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public DigitalAddress DigitalAddress { get; set; }
    }

    public class DigitalAddress
    {
        public string digitalAddress { get; set; }
        public string Dig_Longitude { get; set; }
        public string Dig_Latitude { get; set; }
        public string Dig_Street { get; set; }
        public string Dig_Region { get; set; }
        public string Dig_Area { get; set; }
        public string Dig_District { get; set; }
        public string Dig_PostCode { get; set; }
    }
}