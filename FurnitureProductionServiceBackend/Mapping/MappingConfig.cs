using AutoMapper;
using FurnitureProductionServiceBackend.DTOs;
using FurnitureProductionServiceBackend.Models;

namespace FurnitureProductionServiceBackend
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<EmployeeSpecialization, EmployeeSpecializationDto>().ReverseMap();
            CreateMap<ManufactureSpecialization, ManufactureSpecializationDto>().ReverseMap();
            CreateMap<ProductionStatus, ProductionStatusDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<FurnitureCollection, FurnitureCollectionDto>().ReverseMap();
            
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
