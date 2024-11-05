using Microsoft.AspNetCore.Mvc;
using FurnitureProductionServiceBackend.Models;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Repositories;
using AutoMapper;

[ApiController]
[Route("api/[controller]")]
public class ProductionStatusController : ClassificatorController<ProductionStatus, ProductionStatusDto>
{
    public ProductionStatusController(IClassificatorRepository<ProductionStatus> repository, IMapper mapper)
        : base(repository, mapper)
    {
    }
}
