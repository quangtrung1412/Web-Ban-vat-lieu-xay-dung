using App.Producting.Api.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Producting.Api.Application.Factories;

public class ProductDbContextFactory : IDbContextFactory<ProductDbContext>
{
    private readonly DbContextOptions<ProductDbContext> _options;
    private readonly Func<DbContextOptions<ProductDbContext>, ProductDbContext> _factory;

    public ProductDbContextFactory(DbContextOptions<ProductDbContext> options, Func<DbContextOptions<ProductDbContext>, ProductDbContext> factory)
    {
        _options = options;
        _factory = factory;
    }
    public ProductDbContext CreateDbContext()
    => _factory(_options);

}