using Application.Interfaces.Services;
using Application.Mappings;
using Application.Services;
using Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // Register FluentValidation
            services.AddValidatorsFromAssemblyContaining<UserDTOValidator>();

            // Register Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();

            return services;
        }
    }
} 