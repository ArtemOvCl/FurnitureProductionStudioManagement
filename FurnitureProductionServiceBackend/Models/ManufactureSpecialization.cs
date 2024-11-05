using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FurnitureProductionServiceBackend.Models
{
    public class ManufactureSpecialization : IIdentifiable
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Manufacture> Manufactures { get; set; }
    }
}
