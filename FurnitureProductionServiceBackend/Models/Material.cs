using System.Collections.Generic;

namespace FurnitureProductionServiceBackend.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string MaterialComponents { get; set; }

        public virtual ICollection<Furniture> Furnitures { get; set; }
    }
}
