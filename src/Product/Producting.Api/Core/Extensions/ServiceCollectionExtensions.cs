
using App.Producting.Api.Application.Factories;
using App.Producting.Api.Application.Repositories;
using App.Producting.Api.Application.Service;
using App.Producting.Api.Core.Data;
using App.Producting.Api.Core.Repositories;
using App.Producting.Api.Core.Service;
using App.Producting.Producting.Api.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Producting.Api.Core.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddStorageContext(this IServiceCollection services, string connectionString)
    {
        var memoryContext = new ProductMemoryContext();
        return services.AddOracle<ProductDbContext>(connectionString)
        .AddSingleton<IDbContextFactory<ProductDbContext>>(sp =>
        {
            var opt = new DbContextOptionsBuilder<ProductDbContext>()
             .UseOracle(connectionString).Options;
            return new ProductDbContextFactory(opt, options => new ProductDbContext(options));
        })
        .AddSingleton(memoryContext);
    }
    public static IServiceCollection AddScopedService(this IServiceCollection services)
    {
        services.AddScoped<IProductService,ProductService>()
        .AddScoped<ICategoryService,CategoryService>()
        .AddScoped<ITradeMarkService,TradeMarkService>()
        .AddScoped<IProductRepositories,ProductRepositories>()
        .AddScoped<ICategoryRepositories,CategoryRepositories>()
        .AddScoped<ITradeMarkRepositories,TradeMarkRepositories>();
        return services;
    }
}