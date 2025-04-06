using IntraNet.Entities;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace IntraNet
{
    public class EmployeeSeeder : Seeder<Employee>
    {
        private IPasswordHasher<Employee> _hasher { get; set; }
        public EmployeeSeeder(IntraNetDbContext context, IPasswordHasher<Employee> hasher) : base(context)
        {
            _hasher = hasher;
        }

        public override IEnumerable<Employee> GetItems()
        {
            var employees = new List<Employee>();

            var admin = new Employee()
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@mail.com",
                Position = "Administrator",
                Status = "Active",
                RoleId = 3
            };
            admin.Password = _hasher.HashPassword(admin, "adminadmin");

            employees.Add(admin);
            return employees;

        }
    }
}
