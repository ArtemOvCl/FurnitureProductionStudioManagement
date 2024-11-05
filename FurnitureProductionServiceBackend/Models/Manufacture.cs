using System.Collections.Generic;

namespace FurnitureProductionServiceBackend.Models
{
    public class Manufacture
    {
        public int Id { get; set; }
        
        public string? Address { get; set; }
        
        public int CityId { get; set; }
        public int ManufactureSpecializationId { get; set; }

        public virtual City? City { get; set; } 
        public virtual ManufactureSpecialization? ManufactureSpecialization { get; set; } 
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
