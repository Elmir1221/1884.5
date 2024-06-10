using miniporjectmvc.Data;
using miniporjectmvc.Models;
using miniporjectmvc.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace miniporjectmvc.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private SliderService(AppDbContext context)
        {
           _context = context;
        }
        public async Task<IEnumerable<Slider>> GetAllSlidersAsync()
        {
            return await _context.Sliders.Where(m => !m.SoftDeleted).ToList();
        }
    }
}
