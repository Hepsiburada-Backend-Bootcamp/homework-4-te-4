using System;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infrastructure.Context;
using Ecommerce.Infrastructure.DapperRepository;
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
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProductRepository,DapperProductRepository>();
            services.AddScoped<IUserRepository, DapperUserRepository>();
            return services;
        }
    }
}