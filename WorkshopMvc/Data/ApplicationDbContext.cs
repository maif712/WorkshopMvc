using Microsoft.EntityFrameworkCore;
using WorkshopMvc.Models;

namespace WorkshopMvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
