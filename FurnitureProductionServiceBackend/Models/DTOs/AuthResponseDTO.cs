using System.Collections.Generic;

namespace FurnitureProductionServiceBackend.DTOs
{
    public class AuthResponseDto
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
