using Microsoft.Extensions.DependencyInjection;
using FidelityCard.Application.Services;

namespace FidelityCard.Application.Common;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        return services;
    }
}