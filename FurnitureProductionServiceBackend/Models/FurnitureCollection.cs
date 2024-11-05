using System.Collections.Generic;

namespace FurnitureProductionServiceBackend.Models
{
    public class FurnitureCollection : IIdentifiable
    {
        public int Id { get; set; }
        public string CollectionName { get; set; }

        public virtual ICollection<Furniture> Furnitures {get; set;}
    }
}
