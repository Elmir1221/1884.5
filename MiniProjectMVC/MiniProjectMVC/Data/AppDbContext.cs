using Microsoft.EntityFrameworkCore;
using MiniProjectMVC.Models;

namespace MiniProjectMVC.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<About> Abouts{ get; set; }



    }
}

