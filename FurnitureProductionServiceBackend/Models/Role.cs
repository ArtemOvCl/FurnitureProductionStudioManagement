using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FurnitureProductionServiceBackend.Models
{
    public class Role : IIdentifiable
    {
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
