using Hyperativa.Business.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hyperativa.Business.Services
{
    public static class TokenService
    {
        private static IConfiguration _configuration;
        
        public static string GenerateToken(User user)
        {
            //var teste = _configuration.GetSection("TokenSecret").GetSection("Secret").Value;
            var tokenHandler = new JwtSecurityTokenHandler();

            TokenSecret
            //var key = Encoding.ASCII.GetBytes(_configuration.GetSection("TokenSecret").GetSection("Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Access.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
