using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RedisCacheProject.Context;
using RedisCacheProject.Mapper;
using RedisCacheProject.Repository;
using RedisCacheProject.Repository.Interface;
using RedisCacheProject.Services;
using RedisCacheProject.Services.Interface;

namespace RedisCacheProject.IOC
{
    public static class Dependencies
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Db
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Connection"));
            });

            // Redis
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
            });

            // Mapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // Repository
            services.AddScoped<IProductRepository, ProductRepository>();

            // Service
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
