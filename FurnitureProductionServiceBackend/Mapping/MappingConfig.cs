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
            CreateMap<Manufacture, ManufactureDto>().ReverseMap();

            CreateMap<Furniture, FurnitureDto>().ReverseMap();

            CreateMap<Furniture, FurnitureItemDto>().ReverseMap();

            CreateMap<Material, MaterialDto>().ReverseMap();
        }
    }
}
