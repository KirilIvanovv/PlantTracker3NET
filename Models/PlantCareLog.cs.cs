using System;

namespace PlantTracker3NET.Models
{
    public class PlantCareLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now; 
        public string ActionTaken { get; set; } = string.Empty; 

        public int PlantId { get; set; }
        public Plant? Plant { get; set; }
    }
}