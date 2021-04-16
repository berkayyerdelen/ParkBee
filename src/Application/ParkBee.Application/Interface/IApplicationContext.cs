using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ParkBee.Application.Interface
{
    public interface IApplicationContext
    {
        DbSet<TEntity> Set<TEntity>()
           where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
