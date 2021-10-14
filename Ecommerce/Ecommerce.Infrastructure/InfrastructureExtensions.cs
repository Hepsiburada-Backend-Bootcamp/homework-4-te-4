using System;
using System.Data;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infrastructure.Context;
using Ecommerce.Infrastructure.DapperRepository;
using Ecommerce.Infrastructure.EFRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<EcommerceDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"),
                        b => b.MigrationsAssembly("Ecommerce.API")));
            services.AddScoped<IProductRepository,DapperProductRepository>();
            services.AddScoped<IUserRepository, EFUserRepository>();

            services.AddScoped<IDbConnection>(db=>new SqlConnection(configuration.GetConnectionString("PostgresConnection")));
            return services;
        }
    }
}