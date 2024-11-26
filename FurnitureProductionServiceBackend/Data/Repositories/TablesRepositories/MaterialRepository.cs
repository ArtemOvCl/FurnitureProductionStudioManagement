using FurnitureProductionServiceBackend.Data;
using FurnitureProductionServiceBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureProductionServiceBackend.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly FurnitureProductionContext _context;

        public MaterialRepository(FurnitureProductionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Material>> GetAllAsync()
        {
            return await _context.Materials
                .Include(m => m.Furnitures)
                .ToListAsync();
        }

        public async Task<Material> GetByIdAsync(int id)
        {
            return await _context.Materials
                .Include(m => m.Furnitures)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Material material)
        {
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Material material)
        {
            _context.Materials.Update(material);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
                await _context.SaveChangesAsync();
            }
        }
    }
}
