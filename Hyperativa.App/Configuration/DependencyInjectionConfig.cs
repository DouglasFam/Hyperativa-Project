using Hyperativa.Business.Interfaces.IRepository;
using Hyperativa.Business.Interfaces.IServices;
using Hyperativa.Business.Services;
using Hyperativa.Data.Context;
using Hyperativa.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperativa.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICardService, CardService>();

            return services;
        }
    }
}
