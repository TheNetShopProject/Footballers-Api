using Application.Interfaces;
using Application.Mappings;
using Application.ModelsDTO;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Infrastructure.Repositiries;
using Infrastructure.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IFootballerRepository, FootbllerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IValidator<CreateUserDTO>, CreateUserValidator>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            return services;
        }
    }
}