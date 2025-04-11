using IntraNet.Entities;
using IntraNet.Seeders;
using Microsoft.AspNetCore.Identity;

namespace IntraNet
{
    public  class RoleSeeder : Seeder<Role>
    {
        public RoleSeeder(IntraNetDbContext context) : base(context)
        { 
        }

        public override IEnumerable<Role> GetItems()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Supervisor"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };
            return roles;
        }
    }
}
