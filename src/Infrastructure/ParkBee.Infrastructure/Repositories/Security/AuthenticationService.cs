using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParkBee.Core.Common.DTO;
using ParkBee.Core.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParkBee.Infrastructure.Repositories.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtOptions _config;
        public AuthenticationService(IOptions<JwtOptions> config)
        {
            _config = config.Value;
        }
        public TokenResponseModel GenerateJwtSecurityToken(TokenRequestModel tokenRequestModel)
        {
         


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, tokenRequestModel.UserName),
                    new Claim(ClaimTypes.Role, tokenRequestModel.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer =_config.Issuer,
                Audience =_config.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return new TokenResponseModel()
            {
                Token = tokenHandler.WriteToken(token),
                ExpirationDate = tokenDescriptor.Expires.Value
            };           
        }
    }
}
