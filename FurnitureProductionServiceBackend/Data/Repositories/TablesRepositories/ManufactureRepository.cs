using FurnitureProductionServiceBackend.Data;
using FurnitureProductionServiceBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureProductionServiceBackend.Repositories
{
    public class ManufactureRepository : IManufactureRepository
    {
        private readonly FurnitureProductionContext _context;

        public ManufactureRepository(FurnitureProductionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manufacture>> GetAllAsync()
        {
            return await _context.Manufactures
                .Include(m => m.City)
                .Include(m => m.ManufactureSpecialization)
                .ToListAsync();
        }

        public async Task<Manufacture> GetByIdAsync(int id)
        {
            return await _context.Manufactures
                .Include(m => m.City)
                .Include(m => m.ManufactureSpecialization)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Manufacture manufacture)
        {
            await _context.Manufactures.AddAsync(manufacture);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Manufacture manufacture)
        {
            _context.Manufactures.Update(manufacture);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var manufacture = await _context.Manufactures.FindAsync(id);
            if (manufacture != null)
            {
                _context.Manufactures.Remove(manufacture);
                await _context.SaveChangesAsync();
            }
        }
    }
}
