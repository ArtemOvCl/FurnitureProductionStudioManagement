using System.Collections.Generic;

namespace FurnitureProductionServiceBackend.Models
{
    public class FurnituresProduction
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int StatusId { get; set; }
        public decimal TotalCost { get; set; }
        public int QuantityOfProducedGoods { get; set; }
        public int FurnitureId { get; set; }

        public virtual ProductionStatus? Status { get; set; } 
        public virtual Furniture? Furniture { get; set; } 
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
