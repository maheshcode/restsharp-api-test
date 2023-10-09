

namespace restsharp_api_test.model
{
    public record Data
    {
        public long? Year { get; set; }
        public string? CpuModel { get; set; }
        public string? HardDiskSize { get; set; }
        public string? StrapColour { get; set; }
        public string? CaseSize { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
        public string? Capacity { get; set; }
        public double? ScreenSize { get; set; }
        public string? Generation { get; set; }
        public double? Price { get; set; } 
    }
}
