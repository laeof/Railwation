using Application.Interface.Repository;
using Application.Interface.Service;
using Infrastructure.Persistence;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IBorderCrossingRepository, BorderCrossingRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();

        services.AddScoped<IIntegrationService, IntegrationService>();

        services.AddDbContext<AppDbContext>(options =>
        {
           options.UseNpgsql(
               $"Host={Environment.GetEnvironmentVariable("ASPNETCORE_DB_SERVER")};" +
               $"Port={Environment.GetEnvironmentVariable("ASPNETCORE_DB_PORT")};" +
               $"Username={Environment.GetEnvironmentVariable("ASPNETCORE_DB_USER")};" +
               $"Password={Environment.GetEnvironmentVariable("ASPNETCORE_DB_PASS")};" +
               $"Database={Environment.GetEnvironmentVariable("ASPNETCORE_DB_NAME")};");
        });

        //  services.AddDbContext<AppDbContext>(x => x.UseNpgsql("Host=127.0.0.1;Port=5432;Username=postgres;Password=bt7iC4nN07T0f1nDmyp4ss;Database=railwation"));

        return services;
    }
}
