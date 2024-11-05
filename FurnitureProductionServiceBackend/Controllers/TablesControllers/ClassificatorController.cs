using Microsoft.AspNetCore.Mvc;
using FurnitureProductionServiceBackend.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class ClassificatorController<T, TDto> : ControllerBase where T : class, IIdentifiable
{
    private readonly IClassificatorRepository<T> _repository;
    private readonly IMapper _mapper;

    public ClassificatorController(IClassificatorRepository<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        var entities = await _repository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<TDto>>(entities);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        var dto = _mapper.Map<TDto>(entity);
        return Ok(dto);
    }

    [HttpPost]
    [Authorize(Policy = "RequireAdminRole")]
    public async Task<IActionResult> Create(TDto dto)
    {

        var entity = _mapper.Map<T>(dto);
        await _repository.AddAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null) return NotFound();

        await _repository.DeleteAsync(id); 
        return NoContent();
    }
}
