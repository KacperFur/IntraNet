using IntraNet.Entities;

namespace IntraNet
{
    public class RoleSeeder
    {
        private readonly IntraNetDbContext _context;
        public RoleSeeder(IntraNetDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Database.CanConnect())
            {
                if (!_context.Roles.Any()) 
                {
                    var roles = GetRoles();
                    _context.Roles.AddRange(roles);

                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
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
