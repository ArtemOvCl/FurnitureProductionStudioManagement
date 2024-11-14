using FurnitureProductionServiceBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureProductionServiceBackend.Repositories
{
    public interface IManufactureRepository
    {
        Task<IEnumerable<Manufacture>> GetAllAsync();
        Task<Manufacture> GetByIdAsync(int id);
        Task AddAsync(Manufacture manufacture);
        Task UpdateAsync(Manufacture manufacture);
        Task DeleteAsync(int id);
    }
}
