using Microsoft.EntityFrameworkCore;
using FurnitureProductionServiceBackend.Data;

namespace FurnitureProductionServiceBackend.Repositories{
    public class ClassificatorRepository<T> : IClassificatorRepository<T> where T : class
    {
        private readonly FurnitureProductionContext _context;
        private readonly DbSet<T> _dbSet;

        public ClassificatorRepository(FurnitureProductionContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
