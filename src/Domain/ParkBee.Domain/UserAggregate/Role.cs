using ParkBee.Domain.Core.Base;
using System.Collections.Generic;

namespace ParkBee.Domain.UserAggregate
{
    public class Role : ValueObject
    {
        public string Roles { get; }

        protected Role(string roles)
        {
            Roles = roles;
        }
        public static Role CreateRole(string role) => new(role);
       
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Roles;
        }
    }
}