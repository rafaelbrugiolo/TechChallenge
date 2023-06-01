using TechChallenge.Infrastructure.Extensions;
using TechChallenge.Application.Common;
using Microsoft.EntityFrameworkCore;
using TechChallenge.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<DatabaseContext>();
builder.Services.AddTransient<DbContext, DatabaseContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MigrateDatabase();

app.Run();
