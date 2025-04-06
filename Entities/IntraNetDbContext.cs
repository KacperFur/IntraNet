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
           

            //modelBuilder.Entity<EmployeeTask>().HasOne(e => e.TaskAuthor)
            //    .WithMany(w => w.Tasks).HasForeignKey(z => z.AuthorId)
            //    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmployeeTask>().HasOne(e => e.AssignedEmployee)
                .WithMany(w => w.TasksAssigned).HasForeignKey(z => z.AssignedEmployeeId)
                .OnDelete(DeleteBehavior.SetNull);



            modelBuilder.Entity<Event>().HasOne(e => e.EventAuthor)
                .WithMany(w => w.Events).HasForeignKey(z => z.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Employee>().HasOne(e=>e.Role)
                .WithMany().HasForeignKey(z=>z.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            //przy dwoch odwolaniach do tej samej encji potrzeba usunac kaskadowe usuwanie
        }
    }
}
