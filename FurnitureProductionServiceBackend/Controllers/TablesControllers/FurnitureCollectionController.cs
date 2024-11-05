using Microsoft.AspNetCore.Mvc;
using FurnitureProductionServiceBackend.Models;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Repositories;
using AutoMapper;

[ApiController]
[Route("api/[controller]")]
public class FurnitureCollectionController : ClassificatorController<FurnitureCollection, FurnitureCollectionDto>
{
    public FurnitureCollectionController(IClassificatorRepository<FurnitureCollection> repository, IMapper mapper)
        : base(repository, mapper)
    {
    }
}
