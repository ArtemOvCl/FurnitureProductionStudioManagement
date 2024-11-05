using Microsoft.AspNetCore.Mvc;
using FurnitureProductionServiceBackend.Models;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Repositories;
using AutoMapper;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ClassificatorController<Role, RoleDto>
{
    public RoleController(IClassificatorRepository<Role> repository, IMapper mapper)
        : base(repository, mapper)
    {
    }
}
