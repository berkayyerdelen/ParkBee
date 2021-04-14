using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBee.Infrastructure.Repositories.Security
{
    public class JwtOptions
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
    }
}
