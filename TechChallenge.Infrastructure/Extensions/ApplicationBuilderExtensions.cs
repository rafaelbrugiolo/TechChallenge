using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;

namespace TechChallenge.Infrastructure.Extensions;
public static class ApplicationBuilderExtensions
{
    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
        context.Database.Migrate();
    }
}