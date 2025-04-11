using IntraNet.Middleware;

namespace IntraNet.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
            return services;
        }
    }
}
