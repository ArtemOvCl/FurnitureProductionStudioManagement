using System.Collections.Generic;
using FurnitureProductionServiceBackend.DTOs;

namespace FurnitureProductionServiceBackend.Models
{
    public class EmployeeSpecialization : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}