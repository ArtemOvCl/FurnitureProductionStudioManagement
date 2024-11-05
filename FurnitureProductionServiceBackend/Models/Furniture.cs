using System.Collections.Generic;

namespace FurnitureProductionServiceBackend.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FurnitureCollectionId { get; set; }
        public double Depth { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public double MaximumLoad { get; set; }
        public decimal Cost { get; set; }

        public virtual FurnitureCollection? FurnitureCollection { get; set; } 
        public virtual ICollection<Material> Materials { get; set; }

        
    }
}
