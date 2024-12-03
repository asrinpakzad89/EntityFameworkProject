using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Persistence.Repositories;

public class UserRepository : EFRepositories<User>, IUserRepository
{
    public UserRepository(ApplicationDBContext dbCotext) 
        : base(dbCotext)
    {
    }
    public async Task<User> GetUserByUsernameAndPassword(string username, string password, CancellationToken cancellationToken)
    {
        return await _dbSet.Where(s => s.Username == username && s.Password == password).FirstOrDefaultAsync();
    }
}
