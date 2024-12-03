using Domain.Entities.Users;

namespace Persistence.Repositories;

public interface IUserRepository : IEFRepositories<User> 
{
    Task<User> GetUserByUsernameAndPassword(string username, string password, CancellationToken cancellationToken);
}
