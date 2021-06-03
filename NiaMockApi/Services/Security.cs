using Microsoft.IdentityModel.Tokens;
using NiaMockApi.DTO.Request;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NiaMockApi.Services
{
    public static class Security
    {
        /// <summary>
        /// Generate NIA Api Authentication Token
        /// </summary>
        /// <returns>Base64 string</returns>
        private static string GenerateNiaAuthToken(AuthenticationRequest request)
        {
            var authorization = $"{request.UserName}:{request.Password}";

            var conversion = Encoding.UTF8.GetBytes(authorization);

            return Convert.ToBase64String(conversion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GenerateJwtToken(AuthenticationRequest request)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(GenerateNiaAuthToken(request));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserName", request.UserName) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
