using Microsoft.AspNetCore.Mvc;
using FurnitureProductionServiceBackend.Models;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Repositories;
using AutoMapper;

[ApiController]
[Route("api/[controller]")]
public class EmployeeSpecializationController : ClassificatorController<EmployeeSpecialization, EmployeeSpecializationDto>
{
    public EmployeeSpecializationController(IClassificatorRepository<EmployeeSpecialization> repository, IMapper mapper)
        : base(repository, mapper)
    {
    }
}
