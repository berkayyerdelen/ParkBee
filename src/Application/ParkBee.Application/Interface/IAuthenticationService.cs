using ParkBee.Core.Common.Dto;
using System.Threading.Tasks;

namespace ParkBee.Core.Interface
{
    public interface IAuthenticationService
    {
        TokenResponseModel GenerateSecurityToken(TokenRequestModel tokenRequestModel);
    }
}
