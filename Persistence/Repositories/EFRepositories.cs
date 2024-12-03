using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class EFRepositories<TEntity> : IEFRepositories<TEntity>
    where TEntity : class
{
    public readonly ApplicationDBContext _dbCotext;
    public readonly DbSet<TEntity> _dbSet;

    public EFRepositories(ApplicationDBContext dbCotext)
    {
        _dbCotext = dbCotext;
        _dbSet = _dbCotext.Set<TEntity>();
    }
    public async Task<TEntity?> GetAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken).ConfigureAwait(false);

        }
        catch (Exception ex)
        {
            var msg = ex.Message;
        }
        return null;
    }
    public async Task<ICollection<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.CountAsync(cancellationToken);
    }
    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_dbCotext.Update<TEntity>(entity).Entity);
    }
    public Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_dbCotext.Remove(entity).Entity);
    }

    public async Task SaveChangeAsync(CancellationToken cancellationToken = default)
    {
        await _dbCotext.SaveChangesAsync(cancellationToken);
    }

}
