using System;

namespace ParkBee.Core.Common.Dto
{
    public class TokenResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
