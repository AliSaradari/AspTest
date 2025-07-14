using AspTest.Common.UnitOfWorks;
using AspTest.Configs.BackgroundServices;
using AspTest.DataAccess.DbContexts;
using AspTest.DataAccess.Repositories;
using AspTest.DataAccess.UnitOfWorks;
using AspTest.ServiceLayer.Counties;
using AspTest.ServiceLayer.Counties.Contracts;
using AspTest.ServiceLayer.Provinces;
using AspTest.ServiceLayer.Provinces.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AspTest.Configs.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EFDataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ProvinceService, ProvinceAppService>();
        services.AddScoped<ProvinceRepository, EFProvinceRepository>();
        services.AddScoped<CountyService, CountyAppService>();
        services.AddScoped<CountyRepository, EFCountyRepository>();

        services.AddHostedService<UpdateCityNamesBackgroundService>();
        return services;
    }
}