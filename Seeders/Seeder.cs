using IntraNet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IntraNet.Seeders
{
    public abstract class Seeder<T> where T : class // T must be a class
    {
        protected readonly IntraNetDbContext _context;
        protected readonly DbSet<T> _dbSet;

        protected Seeder(IntraNetDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task SeedAsync()
        {
            if (await _context.Database.CanConnectAsync() && !await _dbSet.AnyAsync())
            {
                await _dbSet.AddRangeAsync(GetItems());
                await _context.SaveChangesAsync();
            }
        }
        public abstract IEnumerable<T> GetItems();
    }
}
