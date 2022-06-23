using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using EMS.Business.Contracts;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Implementations
{
    public class TokenBusiness : ITokenBusiness
    {
        private IConfiguration _configuration;
        private const string IssuerConfigKey = "Jwt:Issuer";
        private const string ExpiryConfigKey = "Jwt:ExpiryInMinutes";
        public TokenBusiness(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenModel GenerateTokens(User user)
        {
            string token = GenerateAccessToken(new List<Claim>()
                {
                    new Claim("username", user.Name)                    
                });

            return new TokenModel { Token = token };
        }

        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration[IssuerConfigKey],
                audience: _configuration[IssuerConfigKey],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration[ExpiryConfigKey])),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
    }
}
