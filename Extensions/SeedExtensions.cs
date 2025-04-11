namespace IntraNet.Extensions
{
    public static class SeedExtensions
    {

        public static async Task SeedDatabaseAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var myService = scope.ServiceProvider.GetRequiredService<RoleSeeder>();
                await myService.SeedAsync();
                var myService3 = scope.ServiceProvider.GetRequiredService<EmployeeSeeder>();
                await myService3.SeedAsync();
                var myService2 = scope.ServiceProvider.GetRequiredService<EventSeeder>();
                await myService2.SeedAsync();

            }
        }
    }
}
