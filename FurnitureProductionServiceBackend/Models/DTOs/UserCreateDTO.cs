namespace FurnitureProductionServiceBackend.DTOs
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; } 
    }
}
