using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Application.Services;

namespace TechChallenge.Application.Common;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IPersonService, PersonService>();
        return services;
    }
}