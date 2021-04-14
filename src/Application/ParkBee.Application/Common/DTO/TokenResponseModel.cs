using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBee.Core.Common.DTO
{
    public class TokenResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
