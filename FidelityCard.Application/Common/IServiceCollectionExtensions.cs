using Microsoft.Extensions.DependencyInjection;
using FidelityCard.Application.Services;
using FidelityCard.Application.Interfaces;
using System.Runtime.CompilerServices;
using AutoMapper;

namespace FidelityCard.Application.Common;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ICompanyService, CompanyService>();

        services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperConfig>());

        return services;
    }
}