using Microsoft.AspNetCore.Mvc;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Models;
using FurnitureProductionServiceBackend.Repositories;

using AutoMapper;

namespace FurnitureProductionServiceBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufactureController : ControllerBase
    {
        private readonly IManufactureRepository _manufactureRepository;
        private readonly IMapper _mapper;

        public ManufactureController(IManufactureRepository manufactureRepository, IMapper mapper)
        {
            _manufactureRepository = manufactureRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var manufactures = await _manufactureRepository.GetAllAsync();
            var manufactureDtos = _mapper.Map<IEnumerable<ManufactureDto>>(manufactures);
            return Ok(manufactureDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var manufacture = await _manufactureRepository.GetByIdAsync(id);
            if (manufacture == null)
            {
                return NotFound();
            }

            var manufactureDto = _mapper.Map<ManufactureDto>(manufacture);
            return Ok(manufactureDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ManufactureDto manufactureDto)
        {
            var manufacture = _mapper.Map<Manufacture>(manufactureDto);
            await _manufactureRepository.AddAsync(manufacture);
            var createdDto = _mapper.Map<ManufactureDto>(manufacture);
            return CreatedAtAction(nameof(GetById), new { id = manufacture.Id }, createdDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ManufactureDto manufactureDto)
        {
            var existingManufacture = await _manufactureRepository.GetByIdAsync(id);
            if (existingManufacture == null)
            {
                return NotFound();
            }

            _mapper.Map(manufactureDto, existingManufacture);
            await _manufactureRepository.UpdateAsync(existingManufacture);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingManufacture = await _manufactureRepository.GetByIdAsync(id);
            if (existingManufacture == null)
            {
                return NotFound();
            }

            await _manufactureRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
