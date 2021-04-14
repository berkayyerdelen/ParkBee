using Microsoft.EntityFrameworkCore;
using ParkBee.Application.Interface;
using ParkBee.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkBee.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationContext _context;

        public UserRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(string userName, string password)
        {
            return await _context.Set<User>()
                .FirstOrDefaultAsync(x => x.UserCredentials.UserName == userName && x.UserCredentials.Password == password);
        }

        public async Task<List<User>> GetUsersAsync()
        {
           return await _context.Set<User>().ToListAsync();
        }

        public async Task InsertUserAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
        

    }
}
