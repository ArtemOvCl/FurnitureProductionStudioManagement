using AutoMapper;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Models;
using FurnitureProductionServiceBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FurnitureProductionServiceBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialRepository _repository;
        private readonly IMapper _mapper;

        public MaterialController(IMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAll()
        {
            var materials = await _repository.GetAllAsync();
            var materialDtos = _mapper.Map<IEnumerable<MaterialDto>>(materials);
            return Ok(materialDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialDto>> GetById(int id)
        {
            var material = await _repository.GetByIdAsync(id);
            if (material == null) return NotFound();

            var materialDto = _mapper.Map<MaterialDto>(material);
            return Ok(materialDto);
        }

        [HttpPost]
        public async Task<ActionResult<MaterialDto>> Create(MaterialDto materialDto)
        {
            var material = _mapper.Map<Material>(materialDto);
            await _repository.AddAsync(material);

            var createdMaterialDto = _mapper.Map<MaterialDto>(material);
            return CreatedAtAction(nameof(GetById), new { id = createdMaterialDto.Id }, createdMaterialDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MaterialDto materialDto)
        {
            if (id != materialDto.Id) return BadRequest();

            var material = _mapper.Map<Material>(materialDto);
            await _repository.UpdateAsync(material);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
