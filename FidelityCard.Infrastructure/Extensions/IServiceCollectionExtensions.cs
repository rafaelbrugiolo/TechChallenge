using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FidelityCard.Domain.Interfaces;
using FidelityCard.Infrastructure.Database;
using FidelityCard.Infrastructure.Database.Repositories;
using FidelityCard.Infrastructure.FileStorage;

namespace FidelityCard.Infrastructure.Extensions;
public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IConfiguration>();
        var sqlServerConnectionString = configuration.GetConnectionString("SqlServerConnectionString");

        AddRepositories(services);

        services.AddDbContextFactory<DatabaseContext>(options =>
        {
            options.UseSqlServer(sqlServerConnectionString);
            options.EnableSensitiveDataLogging(false);
        }).AddSqlServer<DatabaseContext>(sqlServerConnectionString);

        services.AddTransient<DatabaseContext>();
        services.AddTransient<DbContext, DatabaseContext>();

        services.AddTransient<IStorage, AzureBlobStorage>();

        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        var repositories = Assembly.GetExecutingAssembly().GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IBaseRepository<>)))
            .Select(type => (concreteType: type, @interface: type.GetInterfaces().Last()))
            .ToArray();

        foreach (var repository in repositories)
            if (!repository.@interface.IsGenericType)
                services.AddTransient(repository.@interface, repository.concreteType);
    }
}