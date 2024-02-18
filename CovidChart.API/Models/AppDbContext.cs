using Microsoft.EntityFrameworkCore;

namespace CovidChart.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Covid> Covids { get; set; }
    }
}
