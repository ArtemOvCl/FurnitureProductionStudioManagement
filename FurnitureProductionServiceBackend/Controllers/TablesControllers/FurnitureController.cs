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
public class FurnitureController : ControllerBase
{
    private readonly IFurnitureRepository _repository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _environment;

    public FurnitureController(IFurnitureRepository repository, IMapper mapper, IWebHostEnvironment environment)
    {
        _repository = repository;
        _mapper = mapper;
        _environment = environment;
    }

    [HttpGet]
public async Task<ActionResult<IEnumerable<FurnitureItemDto>>> GetAll()
{
    var furnitures = await _repository.GetAllAsync();
    var furnitureDtos = furnitures.Select(f => new FurnitureItemDto
    {
        Id = f.Id,
        Name = f.Name,
        Cost = f.Cost,
        ImagePath = $"{Request.Scheme}://{Request.Host}/images/furniture/{Path.GetFileName(f.ImagePath)}"
    });

    return Ok(furnitureDtos);
}

    [HttpGet("{id}")]
public async Task<ActionResult<FurnitureDto>> GetById(int id)
{
    var furniture = await _repository.GetByIdAsync(id);
    if (furniture == null)
    {
        return NotFound();
    }

    var furnitureDto = new FurnitureDto
    {
        Id = furniture.Id,
        Name = furniture.Name,
        Description = furniture.Description,
        FurnitureCollectionId = furniture.FurnitureCollectionId,
        Depth = furniture.Depth,
        Width = furniture.Width,
        Length = furniture.Length,
        Weight = furniture.Weight,
        MaximumLoad = furniture.MaximumLoad,
        Cost = furniture.Cost,
        ImagePath = $"{Request.Scheme}://{Request.Host}/images/furniture/{Path.GetFileName(furniture.ImagePath)}",
    };

    return Ok(furnitureDto);
}

    [HttpPost]
    public async Task<ActionResult<FurnitureDto>> Create([FromForm] FurnitureDto furnitureDto)
    {
        var furniture = _mapper.Map<Furniture>(furnitureDto);

        if (furnitureDto.ImageFile != null)
        {
            furniture.ImagePath = await SaveImageAsync(furnitureDto.ImageFile);
        }

        await _repository.AddAsync(furniture);

        var createdFurnitureDto = _mapper.Map<FurnitureDto>(furniture);
        return CreatedAtAction(nameof(GetById), new { id = createdFurnitureDto.Id }, createdFurnitureDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromForm] FurnitureDto furnitureDto)
    {

        var furniture = await _repository.GetByIdAsync(id);
        if (furniture == null) return NotFound();

        _mapper.Map(furnitureDto, furniture);

        if (furnitureDto.ImagePath != null)
        {

            if (!string.IsNullOrEmpty(furniture.ImagePath))
            {
                DeleteImage(furniture.ImagePath);
            }

            furniture.ImagePath = await SaveImageAsync(furnitureDto.ImageFile);
        }

        await _repository.UpdateAsync(furniture);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var furniture = await _repository.GetByIdAsync(id);
        if (furniture == null) return NotFound();

        if (!string.IsNullOrEmpty(furniture.ImagePath))
        {
            DeleteImage(furniture.ImagePath);
        }

        await _repository.DeleteAsync(id);
        return NoContent();
    }

    private async Task<string> SaveImageAsync(IFormFile imageFile)
    {
        var uploadsFolder = Path.Combine(_environment.WebRootPath, "images/furniture");
        Directory.CreateDirectory(uploadsFolder);

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(fileStream);
        }

        return $"/images/furniture/{fileName}";
    }

    private void DeleteImage(string imagePath)
    {
        var fullPath = Path.Combine(_environment.WebRootPath, imagePath.TrimStart('/'));
        if (System.IO.File.Exists(fullPath))
        {
            System.IO.File.Delete(fullPath);
        }
    }
}

}
