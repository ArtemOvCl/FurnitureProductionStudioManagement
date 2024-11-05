using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Models;
using FurnitureProductionServiceBackend.Repositories;
using AutoMapper;
using System.Threading.Tasks;

namespace FurnitureProductionServiceBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")] 
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin, Logistician")] 
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")] 
        public async Task<IActionResult> Create([FromBody] UserCreateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, userDto);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")] 
        public async Task<IActionResult> Update(int id, [FromBody] UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            var userFromDb = await _userRepository.GetByIdAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }

            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateAsync(user);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")] 
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();

            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
