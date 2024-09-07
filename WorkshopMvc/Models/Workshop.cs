namespace WorkshopMvc.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        // Navigation property
        public List<Participant>? Participants { get; set; }
    }
}
