using FurnitureProductionServiceBackend.Data;
using FurnitureProductionServiceBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureProductionServiceBackend.Repositories
{
    public class FurnitureRepository : IFurnitureRepository
    {
        private readonly FurnitureProductionContext _context;

        public FurnitureRepository(FurnitureProductionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Furniture>> GetAllAsync()
        {
            return await _context.Furnitures
                .Include(f => f.Materials)
                .ToListAsync();
        }

        public async Task<Furniture> GetByIdAsync(int id)
        {
            return await _context.Furnitures
                .Include(f => f.Materials)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(Furniture furniture)
        {
            _context.Furnitures.Add(furniture);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Furniture furniture)
        {
            _context.Furnitures.Update(furniture);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var furniture = await _context.Furnitures.FindAsync(id);
            if (furniture != null)
            {
                _context.Furnitures.Remove(furniture);
                await _context.SaveChangesAsync();
            }
        }
    }
}
