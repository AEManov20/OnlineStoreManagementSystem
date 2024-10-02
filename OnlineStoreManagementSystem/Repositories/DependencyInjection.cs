using OnlineStoreManagementSystem.Models;
using OnlineStoreManagementSystem.Repositories.Contracts;
using OnlineStoreManagementSystem.Repositories.Implementations;

namespace OnlineStoreManagementSystem.Repositories;

public static class DependencyInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IDiscountCodeRepository, DiscountCodeRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IProductRepository, ProductRepository>();
    }
    
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Mappings));
    }
}