using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

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
            var response = new AuthResponseDto { Success = false };
            var errors = new Dictionary<string, List<string>>();

            // Перевірка, чи всі необхідні поля заповнені
            if (string.IsNullOrWhiteSpace(loginDto.Name))
            {
                errors.Add("name", new List<string> { "Full Name is required." });
            }

            if (string.IsNullOrWhiteSpace(loginDto.Password))
            {
                errors.Add("password", new List<string> { "Password is required." });
            }

            if (errors.Count > 0)
            {
                response.Errors = errors;
                return response;
            }

            var user = await _userRepository.GetByUsernameAsync(loginDto.Name);
            if (user == null)
            {
                errors.Add("name", new List<string> { "User not found." });
            }
            else
            {
                if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
                {
                    errors.Add("password", new List<string> { "Invalid password." });
                }
            }

            if (errors.Count > 0)
            {
                response.Errors = errors;
                return response;
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

            response.Success = true;
            response.Token = tokenHandler.WriteToken(token);
            return response;
        }
    }
}
