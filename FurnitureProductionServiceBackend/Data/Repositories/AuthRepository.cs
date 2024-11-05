using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FurnitureProductionServiceBackend.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthRepository(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> LoginAsync(UserLoginDto loginDto)
        {
            var user = await _userRepository.GetByUsernameAsync(loginDto.Name);
            if (user == null)
            {
                return new AuthResponseDto { Success = false, Message = "User not found." };
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return new AuthResponseDto { Success = false, Message = "Invalid password." };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role.RoleName) 
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthResponseDto { Success = true, Token = tokenHandler.WriteToken(token) }; 
        }
    }
}
