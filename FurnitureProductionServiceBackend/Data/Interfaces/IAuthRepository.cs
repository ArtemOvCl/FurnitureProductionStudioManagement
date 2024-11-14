using System.Threading.Tasks;
using FurnitureProductionServiceBackend.DTOs;

namespace FurnitureProductionServiceBackend.Repositories
{
    public interface IAuthRepository
    {
        Task<AuthResponseDto> LoginAsync(UserLoginDto loginDto);
    }
}
