using FurnitureProductionServiceBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureProductionServiceBackend.Repositories
{
    public interface IFurnitureRepository
    {
        Task<IEnumerable<Furniture>> GetAllAsync();
        Task<Furniture> GetByIdAsync(int id);
        Task AddAsync(Furniture furniture);
        Task UpdateAsync(Furniture furniture);
        Task DeleteAsync(int id);
    }
}
