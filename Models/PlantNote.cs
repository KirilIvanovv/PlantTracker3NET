using System;
using System.ComponentModel.DataAnnotations;

namespace PlantTracker3NET.Models
{
    public class PlantNote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
