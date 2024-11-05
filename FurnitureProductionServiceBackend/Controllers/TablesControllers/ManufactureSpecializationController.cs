using Microsoft.AspNetCore.Mvc;
using FurnitureProductionServiceBackend.Models;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Repositories;
using AutoMapper;

[ApiController]
[Route("api/[controller]")]
public class ManufactureSpecializationController : ClassificatorController<ManufactureSpecialization, ManufactureSpecializationDto>
{
    public ManufactureSpecializationController(IClassificatorRepository<ManufactureSpecialization> repository, IMapper mapper)
        : base(repository, mapper)
    {
    }
}
