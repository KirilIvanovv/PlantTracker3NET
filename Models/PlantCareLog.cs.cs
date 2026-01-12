using System;
using System.ComponentModel.DataAnnotations;

namespace PlantTracker3NET.Models
{
    public class PlantCareLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        [Required]
        public DateTime ActionDate { get; set; }

        [Required, StringLength(200)]
        public string Action { get; set; } 
    }
}
