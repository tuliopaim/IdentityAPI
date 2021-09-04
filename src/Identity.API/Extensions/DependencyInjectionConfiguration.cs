﻿using Identity.Business.Interfaces;
using Identity.Business.Interfaces.Repositories;
using Identity.Business.Interfaces.Services;
using Identity.Business.Notificacoes;
using Identity.Business.Services;
using Identity.Data;
using Identity.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.API.Extensions
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependences(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ISeedData, SeedData>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}