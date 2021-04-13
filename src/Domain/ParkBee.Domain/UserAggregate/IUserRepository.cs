using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBee.Domain.UserAggregate
{
    public interface IUserRepository
    {
        Task InsertUserAsync(User user);
        Task<List<User>> GetUsersAsync();
    }
}
