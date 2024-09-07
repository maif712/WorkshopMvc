using System.ComponentModel.DataAnnotations;

namespace WorkshopMvc.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Status { get; set; }

        // Foriegn key
        public int WorkshopId { get; set; }

        // Navigation property
        public Workshop? Workshop { get; set; }
    }
}
