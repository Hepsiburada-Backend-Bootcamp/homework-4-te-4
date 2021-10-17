using System;
using System.Data;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infrastructure.Context;
using Ecommerce.Infrastructure.DapperRepository;
using Ecommerce.Infrastructure.EFRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Npgsql;

namespace Ecommerce.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<EcommerceDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"),
                        b => b.MigrationsAssembly("Ecommerce.API"))
                .UseSnakeCaseNamingConvention());
            
            services.Configure<OrderDatabaseSettings>(configuration.GetSection(nameof(OrderDatabaseSettings)));
            services.AddSingleton<IOrderDatabaseSettings>(sp => 
                sp.GetRequiredService<IOptions<OrderDatabaseSettings>>().Value);
            
            services.AddScoped<IOrderMongoContext, OrderMongoContext>();
            
            services.AddScoped<IProductRepository,DapperProductRepository>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IOrderRepository, DapperOrderRepository>();

            services.AddScoped<IDbConnection>(db=>new NpgsqlConnection(configuration.GetConnectionString("PostgresConnection")));
            return services;
        }
    }
}