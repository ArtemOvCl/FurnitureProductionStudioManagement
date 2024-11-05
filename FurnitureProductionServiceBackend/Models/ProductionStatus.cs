using System.Collections.Generic;

namespace FurnitureProductionServiceBackend.Models
{
    public class ProductionStatus : IIdentifiable
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<FurnituresProduction> FurnituresProductions {get; set;}
    }
}