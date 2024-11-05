using FurnitureProductionServiceBackend.Models;
using FurnitureProductionServiceBackend.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;

namespace FurnitureProductionServiceBackend.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly FurnitureProductionContext _context;

        public UserRepository(FurnitureProductionContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.Include(u => u.Role)
                                       .FirstOrDefaultAsync(u => u.Name == username);
        }

        public async Task AddAsync(User user)
        {
            
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

    }
}
