using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public interface IEFRepositories<TEntity> where TEntity : class
{
    Task<TEntity?> GetAsync(int id, CancellationToken cancellationToken);
    Task<ICollection<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    Task<int> CountAsync(CancellationToken cancellationToken);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task SaveChangeAsync(CancellationToken cancellationToken);
}
