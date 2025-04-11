using Microsoft.EntityFrameworkCore;

namespace IntraNet.Entities
{
    public class IntraNetDbContext : DbContext
    {
        public IntraNetDbContext(DbContextOptions<IntraNetDbContext> options) :base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EmployeeTask> Tasks { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IntraNetDbContext).Assembly);
        }
    }
}
