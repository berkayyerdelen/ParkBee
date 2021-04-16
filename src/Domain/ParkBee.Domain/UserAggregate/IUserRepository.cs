using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkBee.Domain.UserAggregate
{
    public interface IUserRepository
    {
        Task InsertUserAsync(User user);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(string userName, string password);
    }
}
