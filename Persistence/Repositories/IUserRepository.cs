using Domain.Entities;

namespace Persistence.Repositories;

public interface IUserRepository : IEFRepositories<User> 
{
    Task<User> GetUserByUsernameAndPassword(string username, string password, CancellationToken cancellationToken);
}
