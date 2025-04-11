namespace IntraNet.Extensions
{
    public static class SeederCollectionExtensions
    {
        public static IServiceCollection AddApplicationSeeders(this IServiceCollection services)
        {
            services.AddScoped<RoleSeeder>();
            services.AddScoped<EventSeeder>();
            services.AddScoped<EmployeeSeeder>();
            return services;
        }
    }
}
