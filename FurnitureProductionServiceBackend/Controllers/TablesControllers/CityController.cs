using Microsoft.AspNetCore.Mvc;
using FurnitureProductionServiceBackend.Models;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Repositories;
using AutoMapper;

[ApiController]
[Route("api/[controller]")]
public class CityController : ClassificatorController<City, CityDto>
{
    public CityController(IClassificatorRepository<City> repository, IMapper mapper)
        : base(repository, mapper)
    {
    }
}
