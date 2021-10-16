using Ecommerce.Application.Services;
using Ecommerce.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services, 
            IConfiguration configuration)
        {
            
            services.AddInfrastructureModule(configuration);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, MockProductRepository>();
            return services;
        }
    }
}
