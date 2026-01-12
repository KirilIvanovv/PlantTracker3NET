using System.ComponentModel.DataAnnotations;

namespace PlantTracker3NET.Models
{
    public class GardenTool
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
