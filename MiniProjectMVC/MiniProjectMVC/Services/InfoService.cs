using Microsoft.EntityFrameworkCore;
using MiniProjectMVC.Data;
using MiniProjectMVC.Models;
using MiniProjectMVC.Services.Interfaces;

namespace MiniProjectMVC.Services
{
    public class InfoService : IInfoService
    {
        private readonly AppDbContext _context;
        public InfoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Info>> GetAllInfoAsync()
        {
            return await _context.Infos.ToListAsync();
        }
    }
}
