using Application.Models;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class JwtService : IJwtService
    {
        public static readonly string UserId = "UserId";

        private readonly IOptions<JwtConfiguration> _jwtConfiguration;
        
        public JwtService(IOptions<JwtConfiguration> jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(UserId, user.Id.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _jwtConfiguration.Value.Issuer,
                audience: _jwtConfiguration.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Value.SecretKey)),
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
