using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repositories;

namespace Persistence.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddPersintance(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:DefaultConnection"];
        services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(connectionString)
        );

        AddRepositories(services);
        return services;
    }
    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped(typeof(IEFRepositories<>), typeof(EFRepositories<>));
        services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
    }
}
