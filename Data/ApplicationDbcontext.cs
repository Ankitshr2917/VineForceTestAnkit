using Microsoft.EntityFrameworkCore;
using VineForceTestAnkit.Models;

namespace VineForceTestAnkit.Data
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):base(options)
        {
            
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<StatewithCounrtry> State { get; set; }
    }
}
