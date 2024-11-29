using eshop.Application;
using eshop.Application.Contracts;
using eshop.Application.Features.Products.Queries.GetProducts;
using eshop.Application.Services;
using eshop.Infrastructure.Data;
using eshop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eshop.API.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddNeccessaryInjections(this IServiceCollection services, string connectionString)
        {

            services.AddScoped<IProductService, ProductService>();
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<GetProductsRequest>());
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUserService, UserService>();


            services.AddDbContext<TKEshopDbContext>(options =>
            {
                options.UseSqlServer(connectionString);

            });

            return services;
        }
    }
}
