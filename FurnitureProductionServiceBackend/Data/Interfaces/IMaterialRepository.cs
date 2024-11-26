using FurnitureProductionServiceBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureProductionServiceBackend.Repositories
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetAllAsync();
        Task<Material> GetByIdAsync(int id);
        Task AddAsync(Material material);
        Task UpdateAsync(Material material);
        Task DeleteAsync(int id);
    }
}
