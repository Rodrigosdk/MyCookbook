
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCookbook.Domain.Repositories;
using MyCookbook.Infrastructure.Database;
using MyCookbook.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MyCookbook.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddContext(services, configurationManager);
        AddUnitOfWork(services);
        AddRepositories(services);
    }

    public static void AddContext(IServiceCollection services, IConfiguration configurationManager)
    {
        var getConnectionString = configurationManager.GetConnectionString("Connection");
        services.AddDbContext<DataContext>(optionsContext => optionsContext.UseSqlServer(getConnectionString));
    }

    public static void AddUnitOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnitWorkRepository, UnitOfWork>();
    }

    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UserRepository>();
    }
}
