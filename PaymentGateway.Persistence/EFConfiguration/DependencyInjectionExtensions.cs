using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Persistence.EFConfiguration
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:PaymentDatabase"]));
            
            return services;
        }
    }
}
