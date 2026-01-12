using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantTracker3NET.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public ICollection<Plant>? Plants { get; set; }
    }
}
