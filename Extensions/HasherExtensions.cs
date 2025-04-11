using IntraNet.Entities;
using Microsoft.AspNetCore.Identity;

namespace IntraNet.Extensions
{
    public static class HasherExtensions
    {
        public static IServiceCollection AddHasher(this IServiceCollection services) 
        { 
            services.AddScoped<IPasswordHasher<Employee>, PasswordHasher<Employee>>();
            return services;
        }
    }
}
