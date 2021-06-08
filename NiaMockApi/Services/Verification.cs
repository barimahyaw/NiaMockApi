using System;
using NiaMockApi.DTO.Request;
using NiaMockApi.DTO.Response;

namespace NiaMockApi.Services
{
    public static class Verification
    {
        /// <summary>
        /// Kyc Verification Finger (with detail ghana card response)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static VerificationFingerResponse KycVerificationFinger(VerificationFingerRequest request)
        {
            if(request == null) return new VerificationFingerResponse();

            var verificationResponse = new VerificationFingerResponse
            {
                Code = "00",
                Success = true,
                Data = new Data
                {
                    TransactionGuid = Guid.NewGuid(),
                    RequestTimestamp = DateTime.Now,
                    ResponseTimestamp = DateTime.Now,
                    Verified = true,
                    Person = new Person
                    {
                        BirthDate = "1985-05-12",
                        CardValidTo = "2020-06-10",
                        Forenames = "NANA ESI",
                        Surname = "MENSAH",
                        NationalId = "GHA-xxxxxxxxx-x",
                        Nationality = "Ghana",
                        Gender = "Female",
                        DigitalAddress = new DigitalAddress
                        {
                            digitalAddress = "GW-0544-2361",
                            Dig_Longitude = "-.266866903100707",
                            Dig_Latitude = "5.657361398457602",
                            Dig_Street = "Kwashieman Ofankor Road",
                            Dig_Region = "Greater Accra",
                            Dig_Area = "OFANKOR",
                            Dig_District = "GA North",
                            Dig_PostCode = "GW0544"
                        }
                    }
                }
            };

            return verificationResponse;

            //return new VerificationFingerResponse();
        }
    }
}
