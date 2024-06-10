using Microsoft.EntityFrameworkCore;
using MiniProjectMVC.Data;
using MiniProjectMVC.Models;
using MiniProjectMVC.Services.Interfaces;

namespace MiniProjectMVC.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        public AboutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<About>> GetAllAboutAsync()
        {
            return await _context.Abouts.ToListAsync();
        }
    }
}
