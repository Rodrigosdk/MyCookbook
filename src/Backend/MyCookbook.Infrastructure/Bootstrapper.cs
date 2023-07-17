using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MyCookbook.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddFluentMigration(services, configurationManager);
    }

    private static void AddFluentMigration(IServiceCollection services, IConfiguration configurationManager)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c=> 
            c.AddPostgres11_0()
            .WithGlobalConnectionString(configurationManager.GetConnectionString("Connection"))
            .ScanIn(Assembly.Load("MyCookbook.Infrastructure")).For.All());
    }
}
