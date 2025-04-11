using IntraNet.Services;

namespace IntraNet.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services) 
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }
    }
}
