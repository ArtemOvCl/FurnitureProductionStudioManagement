using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FurnitureProductionServiceBackend.DTOs;

namespace FurnitureProductionServiceBackend.Models
{
    public class City : IIdentifiable
    {
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; }

        public virtual ICollection<Manufacture> Manufactures { get; set; }
    }
}
