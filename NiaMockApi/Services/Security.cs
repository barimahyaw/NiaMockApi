using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using NiaMockApi.DTO.Request;
using NiaMockApi.DTO.Response;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace NiaMockApi.Services
{
    public class Security : ISecurity
    {
        private readonly IUtilities _utils;
        private readonly IWebHostEnvironment _hostEnvironment;

        public Security(IUtilities utils, IWebHostEnvironment hostEnvironment)
        {
            _utils = utils;
            _hostEnvironment = hostEnvironment;
        }

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
        public string GenerateJwtToken(AuthenticationRequest request)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(GenerateNiaAuthToken(request));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserName", request.UserName),
                    new Claim("Password",request.Password)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Authenticate client against access token
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return false;

            var jsonClientToken = _utils.ReadClientAuthenticationToken();

            var jwt = jsonClientToken.Data.AccessToken;
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            var credentials = token.Claims.ToArray();

            var existingUserName = credentials[0].ToString();
            var existingPassword = credentials[1].ToString();

            return existingUserName == userName && existingPassword == password;
        }

        /// <summary>
        /// Refresh Client Token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public AuthenticationResponse GenerateRefreshedToken(string refreshToken)
        {
            var response = _utils.ReadClientAuthenticationToken();

            return refreshToken == response.Data.RefreshToken ? response : new AuthenticationResponse();
        }
    }
}
