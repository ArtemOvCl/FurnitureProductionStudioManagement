namespace FurnitureProductionServiceBackend.DTOs
{
    public class ManufactureDto
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
        public int ManufactureSpecializationId { get; set; }
    }
}
