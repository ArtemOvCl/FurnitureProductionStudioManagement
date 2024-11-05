using System.Collections.Generic;

namespace FurnitureProductionServiceBackend.Models
{

public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }

    }
}
