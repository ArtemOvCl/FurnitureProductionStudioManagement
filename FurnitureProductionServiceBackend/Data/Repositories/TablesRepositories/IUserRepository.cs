using Microsoft.EntityFrameworkCore;
using FurnitureProductionServiceBackend.Models;

namespace FurnitureProductionServiceBackend.Repositories
{ 
    public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);

}

}

