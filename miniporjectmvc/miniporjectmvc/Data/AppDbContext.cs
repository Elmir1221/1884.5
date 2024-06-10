using Microsoft.EntityFrameworkCore;
using miniporjectmvc.Models;

namespace miniporjectmvc.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }

    }
}
