using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantTracker3NET.Models
{
    public class Plant
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime PlantedDate { get; set; }

        [Required]
        public int WaterEveryDays { get; set; }

        public DateTime? LastWatered { get; set; }

        public string? Comment { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<PlantCareLog>? CareLogs { get; set; }
        public ICollection<PlantNote>? Notes { get; set; }
    }
}
