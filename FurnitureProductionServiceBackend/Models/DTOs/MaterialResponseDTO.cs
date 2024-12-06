namespace FurnitureProductionServiceBackend.DTOs
{
    public class MaterialResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string MaterialComponents { get; set; }
        public string? ImagePath { get; set; }
        public List<int> FurnitureIds { get; set; }
    }
}
