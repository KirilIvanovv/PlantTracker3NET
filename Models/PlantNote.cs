namespace PlantTracker3NET.Models
{
    public class PlantNote
    {
        public int Id { get; set; }
        public string NoteText { get; set; } = string.Empty; 

        public int PlantId { get; set; }
        public Plant? Plant { get; set; }
    }
}