using System.Collections.Generic;

namespace FurnitureProductionServiceBackend.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int SpecializationId { get; set; }
        public string ContactPhone { get; set; }
        public int ManufactureId { get; set; }

        public virtual Manufacture? Manufacture { get; set; } 
        public virtual EmployeeSpecialization? EmployeeSpecialization { get; set; } 
        public virtual ICollection<FurnituresProduction> FurnituresProductions { get; set; }

    }
}
