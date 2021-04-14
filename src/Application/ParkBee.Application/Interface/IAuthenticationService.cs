using ParkBee.Core.Common.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBee.Core.Interface
{
    public interface IAuthenticationService
    {
        TokenResponseModel GenerateJwtSecurityToken(TokenRequestModel tokenRequestModel);
    }
}
