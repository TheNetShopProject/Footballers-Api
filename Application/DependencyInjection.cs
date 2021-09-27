using System.Reflection;
using Application.Interfaces;
using Application.Mappings;
using Application.Middleware;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IFootballerService, FotballerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<RequestTimeHandlingMiddleware>();
            return services;
        }
    }
}